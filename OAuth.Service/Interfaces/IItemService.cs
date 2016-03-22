using OAuth.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Service.Interfaces
{
    public interface IItemService
    {
        Item Get(int id);

        Item Add(Item item);
        
        IPagedList<Item> GetItems(int pageIndex);
    }
}
