using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class UserQuizAttempt:BaseEntity
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid QuizId { get; set; }    
        public Quiz Quiz { get; set; }
        public int Score { get; set; }
        public DateTime AttemptDate { get; set; }   
    }
}
