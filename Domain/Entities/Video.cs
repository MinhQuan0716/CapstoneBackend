using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Video:BaseEntity
    {
        public string VideoTitle { get; set; }
        public string VideoDesciption { get; set; }
        public string VideoUrl { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

    }
}
