using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Lesson:BaseEntity
    {
        public string LessonName { get; set; }
        public TimeSpan LessonDuration { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<LessonVideo> Videos { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<TheoryLesson> TheoryLessons { get; set;}
    }
}
