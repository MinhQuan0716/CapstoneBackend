using Application.InterfaceService;
using Application.ViewModel.QuizModel;
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
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuizService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> CreateQuizAsync(CreateQuizModel createQuizModel)
        {
            try
            {
                Quiz createQuiz = _mapper.Map<Quiz>(createQuizModel);
                await _unitOfWork.QuizRepository.AddAsync(createQuiz);
                await _unitOfWork.SaveChangeAsync();
                Guid quizId = await _unitOfWork.QuizRepository.GetLastSaveQuizId();
                int order = 1;
                foreach (var questionId in createQuizModel.ListQuestionId)
                {
                    QuizDetail createQuizDetail = new QuizDetail
                    {
                        QuizId = quizId,
                        QuestionId = questionId,
                        QuestionOrder = order
                    };
                    order++;
                    await _unitOfWork.QuizDetailRepository.AddAsync(createQuizDetail);
                }
                int isCreated = await _unitOfWork.SaveChangeAsync();
                if (isCreated > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Create successfully", createQuizModel);
                }
            }
            catch (Exception ex)
            {
                return new Respone(HttpStatusCode.InternalServerError, ex.Message, null);
            }
            return new Respone(HttpStatusCode.BadRequest, "Create faild", null);
        }

        public async Task<Respone> DeleteQuizAsync(Guid quizId)
        {

            Quiz deleteQuiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);
            List<Guid> listQuestionId = await _unitOfWork.QuizDetailRepository.GetAllQuestionIdByQuizId(quizId);
            _unitOfWork.QuizRepository.SoftRemove(deleteQuiz);
            foreach (var questionId in listQuestionId)
            {
                QuizDetail quizDetail = await _unitOfWork.QuizDetailRepository.FindQuizDetailById(quizId, questionId);
                if (quizDetail != null)
                {
                    _unitOfWork.QuizDetailRepository.SoftRemove(quizDetail);
                }
            }
            int isDelete = await _unitOfWork.SaveChangeAsync();
            if (isDelete > 0)
            {
                return new Respone(HttpStatusCode.NoContent, "Delete successfully", null);
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete faild", null);
        }
    }
}

