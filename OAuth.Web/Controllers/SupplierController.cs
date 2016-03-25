using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAuth.Domain.Model;
using OAuth.Service.Interfaces;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Web.Controllers
{
    public class SupplierController : BaseController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }
        // GET: Supplier
        public ActionResult Index(int id = 1)
        {
            var list = _supplierService.GetSuppliers(id);
            return View(new PagedList<Supplier>(list, list.CurrentPageIndex, list.PageSize, list.TotalItemCount));
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}