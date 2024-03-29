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
        public string LessonDescription { get;set; }
        public bool IsPremium { get; set; }
        public string? ImageUrl { get; set; }
        public int LessonOrder {  get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
