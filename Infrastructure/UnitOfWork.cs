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
        private readonly ICourseRepository _courseRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IQuizDetailRepository _quizDetailRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;
        private readonly IQuestionDetailRepository _questionDetailRepository;
        public UnitOfWork(AppDbContext appDBContext, IAccountRepository accountRepository, 
            ISongRepository songRepository, ICourseRepository courseRepository, 
            IQuizRepository quizRepository, IQuizDetailRepository quizDetailRepository, 
            IQuestionRepository questionRepository, IChoiceRepository choiceRepository,IQuestionDetailRepository questionDetailRepository)
        {
            _appDBContext = appDBContext;
            _accountRepository = accountRepository;
            _songRepository = songRepository;
            _courseRepository = courseRepository;
            _quizRepository = quizRepository;
            _quizDetailRepository = quizDetailRepository;
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
            _questionDetailRepository= questionDetailRepository;    
        }

        public IAccountRepository AccountRepository => _accountRepository;

        public ISongRepository SongRepository => _songRepository;

        public ICourseRepository CourseRepository => _courseRepository;

        public IQuestionRepository QuestionRepository => _questionRepository;

        public IChoiceRepository ChoiceRepository => _choiceRepository;

        public IQuizDetailRepository QuizDetailRepository => _quizDetailRepository;

        public IQuizRepository QuizRepository =>_quizRepository;

        public IQuestionDetailRepository QuestionDetailRepository => _questionDetailRepository;

        public async Task<int> SaveChangeAsync() => await _appDBContext.SaveChangesAsync();
    }
}

