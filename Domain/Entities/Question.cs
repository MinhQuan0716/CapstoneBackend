using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Question:BaseEntity
    {
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }  
        public string  QuestionText { get; set; }
        public int QuestionOrder { get; set; }
        public string Explaination { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}
