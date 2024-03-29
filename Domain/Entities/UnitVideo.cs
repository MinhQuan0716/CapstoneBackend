using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class UnitVideo:BaseEntity
    {
        public string VideoTitle { get; set; }
        public string VideoDesciption { get; set; }
        public string VideoUrl { get; set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }

    }
}
