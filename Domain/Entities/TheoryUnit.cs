using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class TheoryUnit:BaseEntity   
    {
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
