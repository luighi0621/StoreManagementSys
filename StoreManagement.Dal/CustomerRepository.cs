using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using StoreManagement.Models;
using StoreManagement.Dal.Interfaces;
using System.Data.Entity;

namespace StoreManagement.Dal
{
    public class CustomerRepository : DbContext, ICustomerRepository
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

        public CustomerRepository()
        {
            _Context = new StoreManagementEntities();
        }

        public long Count()
        {
            return _Context.Customers.LongCount();
        }

        public void Create(Customer add)
        {
            if (add != null)
            {
                try
                {
                    _Context.Customers.Add(add);
                    _Context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(Customer delete)
        {
            if (delete != null)
            {
                try
                {
                    _Context.Customers.Remove(delete);
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
            throw new NotSupportedException("Query executions not supported.");
        }

        public Customer Get(Expression<Func<Customer, bool>> condition)
        {
            if (condition != null)
            {
                var singleCustomer = _Context.Customers.Where(condition).FirstOrDefault();
                return singleCustomer;
            }
            return null;
        }

        public IList<Customer> GetAll()
        {
            return _Context.Customers.ToList();
        }

        public void Update(Customer update)
        {
            if (update != null)
            {
                try
                {
                    
                    _Context.Entry(update).State = System.Data.Entity.EntityState.Modified;
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
