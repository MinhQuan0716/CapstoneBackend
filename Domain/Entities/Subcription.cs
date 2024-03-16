using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subcription:BaseEntity
    {
        public string SubcriptionName { get; set; }
        public string SubcriptionDescription { get; set; }
        public decimal Price { get; set; }
        public string Feature {  get; set; }
        public DateTime  BillingCycle { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
