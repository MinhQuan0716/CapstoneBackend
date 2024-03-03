using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PraticeLesson:BaseEntity
    {
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public Guid ListNoteId {  get; set; }   
        public ListNote ListNote { get; set; }
        public bool IsMandatory { get; set; }
    }
}
