using OAuth.Core.Interfaces;
using OAuth.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.IRepository;

namespace OAuth.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IQueryable<User> _users;
        private readonly DbSet<User> _set;

        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
            //_set = dbContext.Set<User>();
        }

        public User Get(int id)
        {
            //string sql = @"SELECT [UserID_int] as Id
            //                  ,[User_nvarchar] as UserName
            //                  ,[Password_nvarchar] as [Password]
            //                  ,[Status_tinyint] as [Status]
            //                  ,[addtime_datetime] as AddDate
            //                  ,[LastAccess_datetime] as LastLogonDate
            //                  ,[DigitalCertificate_nvarchar] as DigitalCertificate
            //                  ,[Phone_nvarchar] as PhoneNumber
            //                  ,[FullName_nvarchar] as FullName
            //              FROM [OP_Users] where UserID_int=1";

            //return _set.SqlQuery(sql).Single();

            return _users.Single(u => u.Id == id);
        }
    }
}
