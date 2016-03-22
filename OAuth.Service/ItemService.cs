using OAuth.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.Model;
using OAuth.Core.Interfaces;
using System.Data.Entity;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Service
{
    public class ItemService : IItemService
    {
        private readonly IRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public Item Add(Item item)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Item> GetItems(int pageIndex)
        {
            var pageList = _repo.GetAll<Item>()//.Include(u => u.UserRoles.Select(r => r.Role))
                //.Where(u => u.Status == 1)
                .OrderByDescending(u=>u.Id)
                //.OrderBy(u => u.Id)
                .ToPagedList(pageIndex, 10);
            return pageList;
        }
    }
}
