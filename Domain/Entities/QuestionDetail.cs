using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionDetail:BaseEntity
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid ChoiceId { get; set; }
        public Choice Choice { get; set; }
        public int ChoiceOrder { get; set; }
    }
}
