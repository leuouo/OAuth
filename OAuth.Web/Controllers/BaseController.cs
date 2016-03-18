using OAuth.Web.Filters;
using System.Web.Mvc;

namespace OAuth.Web.Controllers
{
    //[LoginActionFilter]
    public class BaseController : Controller
    {
        //ajax 错误过滤
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !Request.IsAjaxRequest() || !(filterContext.Exception is HttpAntiForgeryException))
            {
                base.OnException(filterContext);
                return;
            }

            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { Code = 400, message = "非法请求，拒绝访问！" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}