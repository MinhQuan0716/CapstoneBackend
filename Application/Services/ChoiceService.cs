using Application.InterfaceService;
using Application.ViewModel.ChoiceModel;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Application.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> CreateChoiceAsync(CreateChoiceModel choiceModel)
        {
            var createChoice=_mapper.Map<Choice>(choiceModel);
            await _unitOfWork.ChoiceRepository.AddAsync(createChoice);
            if(await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Respone(HttpStatusCode.OK,"Create successfully");
            }
            return new Respone(HttpStatusCode.InternalServerError, "Create failed");
        }

        public async Task<Respone> DeleteChoiceAsync(Guid choiceId)
        {
            List<Choice> choiceList = new List<Choice>();
            Choice choice = await _unitOfWork.ChoiceRepository.GetByIdAsync(choiceId);
            List<Guid> questionIdList = await _unitOfWork.QuestionDetailRepository.GetAllChoiceInQuestionDetail(choiceId);
            foreach (var questionId in questionIdList)
            {
                QuestionDetail questionDetail = await _unitOfWork.QuestionDetailRepository.GetQuestionDetail(questionId, choiceId);
                _unitOfWork.QuestionDetailRepository.SoftRemove(questionDetail);
            }

            _unitOfWork.ChoiceRepository.SoftRemove(choice);
            int isDeleted = await _unitOfWork.SaveChangeAsync();
            if (isDeleted > 0)
            {
                return new Respone(HttpStatusCode.NoContent, "Delete successfully", "");
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete error", "");
        }

        public async Task<Respone> UpdateChoice(Guid choiceId,UpdateChoiceModel updateChoiceModel)
        {
            var choice=await _unitOfWork.ChoiceRepository.GetByIdAsync(choiceId);
            if (choice != null)
            {
                _ = _mapper.Map(updateChoiceModel, choice, typeof(UpdateChoiceModel), typeof(Choice));
                _unitOfWork.ChoiceRepository.Update(choice);
                if(await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Update success", choice);
                }
            }
            return new Respone(HttpStatusCode.BadRequest, "Cannot find choice");
        }
    }
}
