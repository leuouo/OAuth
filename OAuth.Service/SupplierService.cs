using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OAuth.Core.Interfaces;
using OAuth.Domain.IRepository;
using OAuth.Domain.Model;
using OAuth.Service.Interfaces;
using OAuth.Service.ModelDto;
using Webdiyer.WebControls.Mvc;

namespace OAuth.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public Supplier Get(int id)
        {
            return _repo.GetById<Supplier>(id);
        }

        public void Add(SupplierDto entity)
        {
            if (_repo.GetAll<Supplier>().Any(u => u.SupplierName == entity.SupplierName))
            {
                throw new ArgumentException("SupplierName has already existed");
            }

            var supplier = Mapper.Map<SupplierDto, Supplier>(entity);

            //使用UnitOfWork方式
            _unitOfWork.RegisterNew(supplier);
            _unitOfWork.Commit();
        }

        public Supplier GetSupplierById(int id)
        {
            return _repo.GetById<Supplier>(id);
        }

        public IPagedList<Supplier> GetSuppliers(int pageIndex)
        {
            var pageList = _repo.GetAll<Supplier>()
               .OrderBy(u => u.Id)
               .ToPagedList(pageIndex, 10);
            return pageList;
        }

        public void Update(SupplierDto entity)
        {
            var supper = Get(entity.Id);

           
        }

        public void Delate(int id)
        {
            if (id == 0)
            {
                new ArgumentException("传入的Id错误");
            }

            _unitOfWork.RegisterDeleted(Get(id));
            _unitOfWork.Commit();
        }
    }
}
