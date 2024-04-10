using Application.InterfaceRepository;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDBContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ISongRepository _songRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IQuizDetailRepository _quizDetailRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;
        private readonly IQuestionDetailRepository _questionDetailRepository;
        private readonly ITheoryUnitRepository _theoryUnitRepository;
        private readonly IUserQuizAttemptRepository _userQuizAttemptRepository;
        private readonly IPracticeUnitRepository _practiceUnitRepository;
        private readonly IVideoUnitRepository _videoUnitRepository;
        private readonly IUserProgressRepository _userProgressRepository;
        public UnitOfWork(AppDbContext appDBContext, IAccountRepository accountRepository, 
            ISongRepository songRepository, ILessonRepository lessonRepository, 
            IQuizRepository quizRepository, IQuizDetailRepository quizDetailRepository, 
            IQuestionRepository questionRepository, IChoiceRepository choiceRepository,
            IQuestionDetailRepository questionDetailRepository, IUnitRepository unitRepository,
            ITheoryUnitRepository theoryUnitRepository,IUserQuizAttemptRepository userQuizAttemptRepository,
            IPracticeUnitRepository practiceUnitRepository, IVideoUnitRepository videoUnitRepository,IUserProgressRepository userProgressRepository)
        {
            _appDBContext = appDBContext;
            _accountRepository = accountRepository;
            _songRepository = songRepository;
            _unitRepository = unitRepository;
            _lessonRepository = lessonRepository;
            _quizRepository = quizRepository;
            _quizDetailRepository = quizDetailRepository;
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
            _questionDetailRepository = questionDetailRepository;
            _theoryUnitRepository = theoryUnitRepository;
            _userQuizAttemptRepository=userQuizAttemptRepository;
            _practiceUnitRepository = practiceUnitRepository;
            _videoUnitRepository = videoUnitRepository;
            _userProgressRepository = userProgressRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;

        public ISongRepository SongRepository => _songRepository;

        public ILessonRepository LessonRepository => _lessonRepository;
        public IUnitRepository UnitRepository => _unitRepository;

        public IQuestionRepository QuestionRepository => _questionRepository;

        public IChoiceRepository ChoiceRepository => _choiceRepository;

        public IQuizDetailRepository QuizDetailRepository => _quizDetailRepository;

        public IQuizRepository QuizRepository =>_quizRepository;

        public IQuestionDetailRepository QuestionDetailRepository => _questionDetailRepository;

        public ITheoryUnitRepository TheoryUnitRepository => _theoryUnitRepository;

        public IUserQuizAttemptRepository UserQuizAttemptRepository => _userQuizAttemptRepository;
        public IPracticeUnitRepository PracticeUnitRepository => _practiceUnitRepository;

        public IVideoUnitRepository VideoUnitRepository => _videoUnitRepository;

        public IUserProgressRepository UserProgressRepository => _userProgressRepository;

        public async Task<int> SaveChangeAsync() => await _appDBContext.SaveChangesAsync();
    }
}

