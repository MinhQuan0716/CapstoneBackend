using Application.InterfaceService;
using Application.ViewModel.ChoiceModel;
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
                Choice createChoice = new Choice();
                _ = _mapper.Map(choice, createChoice, typeof(CreateChoiceModel), typeof(Choice));
                await _unitOfWork.ChoiceRepository.AddAsync(createChoice);
                await _unitOfWork.SaveChangeAsync();
                QuestionDetail questionDetail = new QuestionDetail
                {
                    QuestionId= await _unitOfWork.QuestionRepository.GetLastSavedQuestion(),
                    ChoiceId= await _unitOfWork.ChoiceRepository.GetLastSavedChoice(),
                    ChoiceOrder= choiceOrder,
                    IsCorrect=choice.IsCorrect,
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
            return new Respone(HttpStatusCode.InternalServerError, "Create failed");
        }

        public async Task<Respone> DeleteQuestionAsync(Guid questionId)
        {
            List<Choice> choiceList = new List<Choice>();
            Question question= await _unitOfWork.QuestionRepository.GetByIdAsync(questionId);
            List<Guid> choiceIdList = await _unitOfWork.QuestionDetailRepository.GetAllChoiceInQuestionDetail(questionId);
            foreach (var choiceId in choiceIdList)
            {
                Choice choice = await _unitOfWork.ChoiceRepository.GetByIdAsync(choiceId);
                choiceList.Add(choice);
                QuestionDetail questionDetail = await _unitOfWork.QuestionDetailRepository.GetQuestionDetail(questionId,choiceId);
                _unitOfWork.QuestionDetailRepository.SoftRemove(questionDetail);
            }
            
            _unitOfWork.QuestionRepository.SoftRemove(question);
           /* _unitOfWork.ChoiceRepository.SoftRemoveRange(choiceList);*/
          int isDeleted=  await _unitOfWork.SaveChangeAsync();
            if (isDeleted > 0)
            {
                return new Respone(HttpStatusCode.NoContent, "Delete successfully","");
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete error", "");
        }

        public async Task<Respone> GetAllQuestionAsync()
        {
            IEnumerable<QuestionViewModel> questionViewModels= await _unitOfWork.QuestionRepository.GetAllQuestions();
            if(questionViewModels.Any())
            {
                return new Respone(HttpStatusCode.OK, "Fetch success", questionViewModels);
            }
            return new Respone(HttpStatusCode.InternalServerError, "Fetch error",null);
        }

        public async Task<Respone> GetQuestionByQuizIdAsync(Guid quizId)
        {
           var result= await _unitOfWork.QuestionRepository.GetQuestionByQuizId(quizId);
            if (result.Any())
            {
                return new Respone(HttpStatusCode.OK, "Fetch successfully",result);
            }
            return new Respone(HttpStatusCode.BadRequest, "Fetch failed");
        }
    }
}
