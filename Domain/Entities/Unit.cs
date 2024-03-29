using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Unit:BaseEntity
    {
        public string UnitName { get; set; }
        public TimeSpan UnitDuration { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public  int UnitOrder { get; set; }
        public ICollection<UnitVideo> Videos { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<TheoryUnit> TheoryUnits { get; set;}
        public ICollection<PraticeUnit> PraticeUnits { get; set;}
    }
}
