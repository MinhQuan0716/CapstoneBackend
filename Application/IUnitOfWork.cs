using Application.InterfaceRepository;
using Application.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IUnitRepository UnitRepository { get; }
        public IAccountRepository AccountRepository { get; }
        public ISongRepository SongRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IChoiceRepository ChoiceRepository { get; }
        public IQuizDetailRepository QuizDetailRepository { get; }
        public IQuizRepository QuizRepository { get; }
        public IQuestionDetailRepository QuestionDetailRepository { get; }
        public ITheoryUnitRepository TheoryUnitRepository { get; }
        public IUserQuizAttemptRepository UserQuizAttemptRepository { get; }
        public IPracticeUnitRepository PracticeUnitRepository { get; }
        public IVideoUnitRepository VideoUnitRepository { get; }
        public IUserProgressRepository UserProgressRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
