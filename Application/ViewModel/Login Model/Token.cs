using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Login_Model
{
    public class Token
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public string RoleName { get; set; }
    }
}
