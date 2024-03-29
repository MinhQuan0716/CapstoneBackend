using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.AccountModel
{
    public class AccountViewModel
    {
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Fullname { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
