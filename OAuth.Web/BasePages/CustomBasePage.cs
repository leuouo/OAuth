
using OAuth.Service.Interfaces;
using System.Web.Mvc;

namespace OAuth.Web.BasePages
{
    public class CustomBasePage : WebViewPage
    {
        public IProjectService projectService { get; set; }


        public override void Execute() { }

        //cyccess 提交代码
    }
}