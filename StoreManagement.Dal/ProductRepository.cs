using StoreManagement.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Models;
using System.Data;
using System.Linq.Expressions;

namespace StoreManagement.Dal
{
    public class ProductRepository : DbContext, IProductRepository
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

        public ProductRepository()
        {
            _Context = new StoreManagementEntities();
        }
        public long Count()
        {
            return _Context.Products.LongCount();
        }

        public void Create(Product add)
        {
            if (add != null)
            {
                try
                {
                    _Context.Products.Add(add);
                    _Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(Product delete)
        {
            if (delete != null)
            {
                try
                {
                    _Context.Products.Add(delete);
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

        public Product Get(Expression<Func<Product, bool>> condition)
        {
            if (condition != null)
            {
                var singleProd = _Context.Products.Where(condition).SingleOrDefault();
                return singleProd;
            }
            return null;
        }

        public IList<Product> GetAll()
        {
            return _Context.Products.Include(p => p.Supplier).ToList();
        }

        public void Update(Product update)
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
    }
}
