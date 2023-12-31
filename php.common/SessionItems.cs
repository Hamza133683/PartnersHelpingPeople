using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace php.common
{
    public static class SessionItems
    {
        public static object Get(SessionKey key)
        {
            return HttpContext.Current.Session[key.ToString()];

        }
        public static void Add(SessionKey key, object value)
        {
            HttpContext.Current.Session.Add(key.ToString(), value);
        }
        public static void RemoveAll()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
        }
        public static void Remove(SessionKey key)
        {
            HttpContext.Current.Session.Remove(key.ToString());
        }
    }
}
