using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Choice:BaseEntity
    {
        public string ChoiceText { get; set; }
        public bool IsCorrect { get; set; }
        public ICollection<QuestionDetail> QuestionDetails { get; set; }
    }
}
