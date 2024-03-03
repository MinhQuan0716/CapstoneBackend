using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class TheoryLesson:BaseEntity   
    {
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
