using Adventure2020.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class SessionStorage<T>: ISessionStorage<T>
    {
        readonly ISession _session;

        public SessionStorage(IHttpContextAccessor hca) // ulozi hodnotu storage
        {
            _session = hca.HttpContext.Session;
        }

        public T LoadOrCreate(string key) // načte/vytvoří data třídy T
        {
            T result = _session.Get<T>(key);
            if (typeof(T).IsClass && result == null) result = (T)Activator.CreateInstance(typeof(T));
            return result;
        }

        public void Save(string key, T data) // uloží data se třídou T s key do storage 
        {
            _session.Set(key, data);
        }
    }
}
