using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Question:BaseEntity
    {
        public string  QuestionText { get; set; }
        public string Explaination { get; set; }
       /* public string? ImageUrl { get; set; }*/
        public ICollection<QuestionDetail> Choices { get; set; }
        public ICollection<QuizDetail> QuizDetail { get; set; }
    }
}
