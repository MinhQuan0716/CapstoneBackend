using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Quiz:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool QuizStatus { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserQuizAttempt> UserQuizAttempts { get; set;}
    }
}
