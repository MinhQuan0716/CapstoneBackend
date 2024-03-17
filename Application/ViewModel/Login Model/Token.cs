using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Login_Model
{
    /// <summary>
    /// Token model for login
    /// </summary>
    public class Token
    {
        public string Username { get; set; }
        /// <summary>
        /// refresh token to get new access token
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        ///  access token for authorize function
        /// </summary>
        public string AccessToken { get; set; }
        public string RoleName { get; set; }
    }
}
