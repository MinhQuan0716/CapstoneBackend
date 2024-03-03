using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Course:BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseDescription { get;set; }
        public DateTime Duration { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
