
using OAuth.Service.Interfaces;
using System.Web.Mvc;

namespace OAuth.Web.BasePages
{
    public class CustomBasePage : WebViewPage
    {
        public IProjectService projectService { get; set; }

        public override void Execute() { }



        //让你更新，我加了新功能，你更新下。
    }
}