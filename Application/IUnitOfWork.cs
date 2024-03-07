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
        public ILessonRepository LessonRepository { get; }
        public IAccountRepository AccountRepository { get; }
        public ISongRepository SongRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IChoiceRepository ChoiceRepository { get; }
        public IQuizDetailRepository QuizDetailRepository { get; }
        public IQuizRepository QuizRepository { get; }
        public IQuestionDetailRepository QuestionDetailRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
