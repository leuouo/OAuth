using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.Model;
using OAuth.Service.ModelDto;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Service.Interfaces
{
    public interface ISupplierService
    {
        Supplier Get(int id);

        void Add(SupplierDto entity);

        Supplier GetSupplierById(int id);

        IPagedList<Supplier> GetSuppliers(int pageIndex);

        void Update(SupplierDto entity);

        void Delate(int id);
    }
}
