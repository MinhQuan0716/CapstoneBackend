using Application.InterfaceService;
using Application.ViewModel.QuestionModel;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Respone> AddQuestionAsync(CreateQuestionModel createQuestionModel)
        {
            Question createdQuestion = new Question
            {
                QuestionText = createQuestionModel.QuestionText,
                Explaination=createQuestionModel.Explanation
            };
            await _unitOfWork.QuestionRepository.AddAsync(createdQuestion);
            await _unitOfWork.SaveChangeAsync();
            int choiceOrder = 1;
            bool flag = false;
            foreach (var choice in createQuestionModel.ChoiceList)
            {
                Choice createChoice =_mapper.Map<Choice>(choice);
                await _unitOfWork.ChoiceRepository.AddAsync(createChoice);
                await _unitOfWork.SaveChangeAsync();
                QuestionDetail questionDetail = new QuestionDetail
                {
                    QuestionId= await _unitOfWork.QuestionRepository.GetLastSavedQuestion(),
                    ChoiceId= await _unitOfWork.ChoiceRepository.GetLastSavedChoice(),
                    ChoiceOrder= choiceOrder
                };
                choiceOrder++;
                await _unitOfWork.QuestionDetailRepository.AddAsync(questionDetail);
                await _unitOfWork.SaveChangeAsync();
                flag = true;
            }
            if (flag)
            {
                return new Respone(HttpStatusCode.OK,"Create successfully");
            }
            return new Respone(HttpStatusCode.InternalServerError, "Create failed",createQuestionModel);
        }
    }
}
