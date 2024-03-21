using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class UserProgress:BaseEntity
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set;}
        public decimal ProgressPercentage { get; set; }
        public bool IsCompleted { get; set; }

    }
}
