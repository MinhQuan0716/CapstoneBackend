using Application.Common;
using Application.InterfaceService;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
namespace Application.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase _db;
        private readonly AppConfiguration _configuration;
        public CacheService(AppConfiguration configuration,IDatabase db)
        {
            _configuration = configuration;
            _db = db;
        }
        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }
        public object UpdateData(string key, object value)
        {
            bool _isKeyExist=_db.KeyExists(key);
            if (_isKeyExist == true)
            {
                SetData<object>(key,value,DateTime.Now.AddMinutes(20));
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
