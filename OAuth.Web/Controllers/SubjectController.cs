using OAuth.Domain.Model;
using OAuth.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Web.Controllers
{
    public class SubjectController : BaseController
    {
        private readonly IItemService _itemService;

        public SubjectController(IItemService itemService)
        {
            this._itemService = itemService;
        }

        // GET: Subject
        public ActionResult Index(int id = 1)
        {
            var pageList = _itemService.GetItems(id);

            return View(new PagedList<Item>(pageList, pageList.CurrentPageIndex, pageList.PageSize, pageList.TotalItemCount));
        }


        public ActionResult List()
        {
            return View();
        }
    }
}