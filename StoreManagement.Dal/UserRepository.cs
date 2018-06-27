using StoreManagement.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Models;
using System.Data;
using System.Linq.Expressions;
using System.Data.Entity;

namespace StoreManagement.Dal
{
    public class UserRepository : DbContext, IUserRepository
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Context.Dispose();
            }
            base.Dispose(disposing);
        }
        private StoreManagementEntities _Context;

        public UserRepository()
        {
            _Context = new StoreManagementEntities();
        }

        public long Count()
        {
            return _Context.Users.LongCount();
        }

        public void Create(User add)
        {
            if (add != null)
            {
                try
                {
                    _Context.Users.Add(add);
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(User delete)
        {
            if (delete != null)
            {
                try
                {
                    _Context.Users.Add(delete);
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            throw new NotSupportedException();
        }

        public User Get(Expression<Func<User, bool>> condition)
        {
            if (condition != null)
            {
                var singleUser = _Context.Users.Where(condition).SingleOrDefault();
                return singleUser;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            return _Context.Users.ToList();
        }

        public void Update(User update)
        {
            if (update != null)
            {
                try
                {
                    _Context.Entry(update).State = EntityState.Modified;
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public System.Data.Entity.DbSet<StoreManagement.Models.User> Users { get; set; }
    }
}
