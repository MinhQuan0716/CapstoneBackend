using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class QuizDetail:BaseEntity
    {
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public Guid QuestionId { get; set; }    
        public Question Question { get; set; }
        public int QuestionOrder { get; set; }  

    }
}
