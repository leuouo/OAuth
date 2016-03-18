using OAuth.Service.Interfaces;
using OAuth.Web.Models;
using System.Web.Mvc;

namespace OAuth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ProjectInfo _projectInfo;

        public HomeController(IUserService userService ,ProjectInfo projectInfo)
        {
            this._userService = userService;
            this._projectInfo = projectInfo;
        }


        public ActionResult TokenLogin(string token)
        {
            Session["Token"] = token; 
            return Redirect("/Project/Index");
        }

        public ActionResult SignOut()
        {
            Session["Token"] = null;
            _projectInfo.Clear();
            return RedirectToAction("Index","Project");
        }

        public ActionResult TestSqlQuery()
        {
            var model = _userService.Get(1);
            return View(model);
        }
    }
}