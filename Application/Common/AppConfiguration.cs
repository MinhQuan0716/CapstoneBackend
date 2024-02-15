using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class AppConfiguration
    {
        public string databaseConnectionString {  get; set; }
        public string cacheConnectionString {  get; set; }
        public string JwtSecretKey { get; set; }
    }
}
