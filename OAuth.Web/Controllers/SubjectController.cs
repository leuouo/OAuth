using OAuth.Domain.Model;
using OAuth.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Web.Controllers
{
    public class SubjectController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly IModeService _modeService;

        public SubjectController(IItemService itemService, IModeService modeService)
        {
            this._itemService = itemService;
            this._modeService = modeService;
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

        public ActionResult Step1(int id = -1)
        {
            Item item = null;
            if (id != -1)
            {
                item = _itemService.Get(id);
            }
            else
            {
                item = new Item();
                item.StartDate = DateTime.Now;
                item.EndDate = DateTime.Now;
            }
            return View(item);
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
            return Json(new { code = 200, message = "询价工程发布成功！" });
        }

        public ActionResult Step2_1()
        {
            return View();
        }

        public ActionResult Step2_2()
        {
            return View();
        }

        public ActionResult Step2_3()
        {
            return View();
        }

        public ActionResult Step2_4()
        {
            return View();
        }

        public ActionResult Step2_5()
        {
            return View();
        }

        public ActionResult Step3()
        {
            return View();
        }

        public ActionResult GetModeJson()
        {
            StringBuilder build = new StringBuilder(5000);
            IEnumerable<Mode> list = _modeService.ModeList();
            
            //var lt = list.Where(p => p.ParentID == -1).ToList();
            //int ltCount = lt.Count();
            //build.Append("{\"sb\":[");
            //for (int i = 0; i < ltCount; i++)
            //{
            //    build.Append("{");
            //    build.Append("\"name\":").Append("\"").Append(lt[i].ModeName).Append("\"").Append(",");
            //    build.Append("\"data\":").Append("[");
            //    var li = list.Where(p => p.ParentID == lt[i].ModeID).ToList();
            //    int liCount = li.Count();
            //    for (int m = 0; m < liCount; m++)
            //    {
            //        build.Append("{");
            //        build.Append("\"").Append("Id").Append("\":");
            //        build.Append("\"").Append(li[m].ModeID).Append("\"");
            //        build.Append(",");
            //        build.Append("\"").Append("Name").Append("\":");
            //        build.Append("\"").Append(li[m].ModeName).Append("\"");
            //        build.Append("}");
            //        if (m != liCount - 1)
            //        {
            //            build.Append(",");
            //        }
            //    }
            //    build.Append("]");
            //    build.Append("}");
            //    if (i != ltCount - 1)
            //    {
            //        build.Append(",");
            //    }
            //}
            //build.Append("]}");

            //IEnumerable<Mode> list = _modeService.ModeList();
            //var lt = list.Where(p => p.ParentID != -1).ToList();
            //build.Append("[");
            //for (int i = 0; i < lt.Count(); i++)
            //{
            //    build.Append("{");
            //    build.Append("").Append("Id").Append(":");
            //    build.Append("'").Append(lt[i].ModeID).Append("'");
            //    build.Append(",");
            //    build.Append("").Append("Name").Append(":");
            //    build.Append("'").Append(lt[i].ModeName).Append("'");
            //    build.Append("}");
            //    if (i != lt.Count() - 1)
            //    {
            //        build.Append(",");
            //    }
            //}
            //build.Append("]");
            return Json(list);// Convert.ToString(build);
        }
    }
}