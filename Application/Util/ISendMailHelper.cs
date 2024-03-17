using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Util
{
    public  interface ISendMailHelper
    {
        public Task<bool> SendMailAsync(string email, string subject, string message);
        public Task<bool> SendMailAsync(List<string> emails, string subject, string message);
    }
}
