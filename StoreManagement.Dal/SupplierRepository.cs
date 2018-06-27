using StoreManagement.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StoreManagement.Models;
using System.Data;
using System.Linq.Expressions;

namespace StoreManagement.Dal
{
    public class SupplierRepository : DbContext, ISupplierRepository
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

        public SupplierRepository()
        {
            _Context = new StoreManagementEntities();
        }

        public long Count()
        {
            return _Context.Suppliers.LongCount();
        }

        public void Create(Supplier add)
        {
            if (add != null)
            {
                try
                {
                    _Context.Suppliers.Add(add);
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(Supplier delete)
        {
            if (delete != null)
            {
                try
                {
                    if (delete.Products != null && delete.Products.Count > 0)
                    {
                        _Context.Products.RemoveRange(delete.Products);
                    }
                    _Context.Suppliers.Remove(delete);
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

        public Supplier Get(Expression<Func<Supplier, bool>> condition)
        {
            if (condition != null)
            {
                var singleSupplier = _Context.Suppliers.Where(condition).SingleOrDefault();
                return singleSupplier;
            }
            return null;
        }

        public IList<Supplier> GetAll()
        {
            return _Context.Suppliers.ToList();
        }

        public void Update(Supplier update)
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

        public System.Data.Entity.DbSet<StoreManagement.Models.Supplier> Suppliers { get; set; }
    }
}
