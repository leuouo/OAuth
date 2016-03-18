
using OAuth.Service.Interfaces;
using System.Web.Mvc;

namespace OAuth.Web.BasePages
{
    public class CustomBasePage : WebViewPage
    {
        public IProjectService projectService { get; set; }


        public override void Execute() { }

        //这里是taimen 提交的内容
    }
}