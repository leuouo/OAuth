using OAuth.Service.Interfaces;
using OAuth.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace OAuth.Web.Filters
{
    public class LoginActionFilter : ActionFilterAttribute
    {
        private static string appid = System.Configuration.ConfigurationManager.AppSettings["appid"];

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            string token = Guid.NewGuid().ToString();
            if (session["Token"] != null)
            {
                token = session["Token"].ToString();
            }

            var _IdentityUser = CheckToken(token);

            if (_IdentityUser.IsAuthenticated == 0)
            {
               filterContext.Result = new RedirectResult(_IdentityUser.LoginUrl + "?appid=" + appid);
            }
        }

        private static IdentityUser CheckToken(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["appid"] = appid;
                p["token"] = token;
                HttpContent content = new FormUrlEncodedContent(p);
                string xml = client.PostAsync(System.Configuration.ConfigurationManager.AppSettings["CheckTokenUrl"], content).Result.Content.ReadAsStringAsync().Result;
                using (StringReader reader = new StringReader(xml))
                {
                    //反序列化对象 
                    XmlSerializer formatter = new XmlSerializer(typeof(IdentityUser));
                    var model = formatter.Deserialize(reader) as IdentityUser;
                    return model;
                }
            }
        }
    }
}