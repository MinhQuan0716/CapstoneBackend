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
using Application.Common;
using Application.InterfaceRepository;
using Application.Util;
using Application.ViewModel.QuestionModel;
using Application.ViewModel.ChoiceModel;
using System.Runtime.CompilerServices;
namespace Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public QuizService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
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

        public async Task<Respone> DoingQuizAsync(Guid quizId, List<DoingQuizViewModel> listAnswers)
        {
            int score = await _unitOfWork.QuestionDetailRepository.CalculationPoint(listAnswers);
            UserQuizAttempt userQuizAttempt = new UserQuizAttempt
            {
                AccountId=_claimService.GetCurrentUserId,
                QuizId=quizId,
                Score=score,
                AttemptDate=DateTime.UtcNow,
            };
            await _unitOfWork.UserQuizAttemptRepository.AddAsync(userQuizAttempt);
            if(await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Respone(HttpStatusCode.OK, "Attempt success", userQuizAttempt);
            }
            return new Respone(HttpStatusCode.BadRequest, "Error");
        }

        public async Task<Respone> GetQuizAsync(Guid unitId, int pageIndex, int pageSize)
        {
           
         QuizViewModel quizViewModels = await _unitOfWork.QuizRepository.GetQuizByUnitIdAsync(unitId);
            List<QuestionWithChoiceViewModel> combineData = new List<QuestionWithChoiceViewModel>();
            List<Choice> choiceList = new List<Choice>();
            List<Choice> distinctChoices = new List<Choice>();
            int totalItemCount = 0;
            foreach(var question in quizViewModels.QuestionTextList)
            {
                List<Guid> listChoiceIdRelatedToQuestion = await _unitOfWork.QuestionDetailRepository.GetAllChoiceInQuestionDetail(question.QuestionId);
                choiceList.Clear();

                // Fetch actual choices using the retrieved Guids
                foreach(var choiceId in listChoiceIdRelatedToQuestion)
                {
                    var choice = await _unitOfWork.ChoiceRepository.GetByIdAsync(choiceId);
                    Console.WriteLine($"Fetched Choice ID: {choice.Id}");
                    choiceList.Add(choice);
                   
                }
                var questionWithChoice = new QuestionWithChoiceViewModel
                {
                    QuizId=quizViewModels.QuizId,
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText,
                    ListChoices=new List<ChoiceViewModelForQuiz>()
                };
                questionWithChoice.ListChoices.AddRange(choiceList.Select(x => new ChoiceViewModelForQuiz
                {
                    ChoiceId = x.Id,
                    ChoiceText = x.ChoiceText
                }));
                combineData.Add(questionWithChoice);
            };
            
            Pagination<QuestionWithChoiceViewModel> pagination=PaginationUtil<QuestionWithChoiceViewModel>.ToPagination(combineData, pageIndex, pageSize);
            if (pagination.Items.Any())
            {
                return new Respone(HttpStatusCode.OK, "fetch ok", pagination);
            }
            return new Respone(HttpStatusCode.BadRequest, "fetch error");
        }

        }
    }



