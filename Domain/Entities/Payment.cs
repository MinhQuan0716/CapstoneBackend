using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Payment:BaseEntity
    {
        public Guid SubcriptionId { get; set; }
        public Subcription Subcription { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}
