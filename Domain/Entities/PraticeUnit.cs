using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PraticeUnit:BaseEntity
    {
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public Guid ListNoteId {  get; set; }   
        public ListNote ListNote { get; set; }
        public bool IsMandatory { get; set; }
    }
}
