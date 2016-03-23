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

        public ActionResult Supplier()
        {
            return View();
        }

        public ActionResult Step1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Step1(Item item)
        {
            item.ItemMode = 1;
            item.InputPerson = 1;
            item.ItemNo = "1";
            item.File1 = "1";
            item.File2 = "1";
            item.InputTime = DateTime.Now;
            _itemService.Add(item);
            return Json(new { code = 200, message = "竞价工程发布成功！" });
        }

        public ActionResult Step2()
        {
            return View();
        }

        public ActionResult Step3()
        {
            return View();
        }
    }
}