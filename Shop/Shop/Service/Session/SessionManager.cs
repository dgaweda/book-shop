using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Shop.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState _session;

        public SessionManager()
        {
            _session = HttpContext.Current.Session;
        }

        public T Get<T>(string key) // get session by key
        {
            return (T)_session[key]; // rzutowanie
        }

        public void Set<T>(string name, T value) // set session
        {
            _session[name] = value;
        }

        public T TryGet<T>(string key)  // return session otherwise null
        {
            try
            {
                return (T)_session[key];
            }
            catch(NullReferenceException)
            {
                return default(T);
            }
        }

        public void Abandon()
        {
            _session.Abandon();
        }
    }
}