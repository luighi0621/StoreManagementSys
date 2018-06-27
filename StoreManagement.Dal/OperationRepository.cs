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
using System.Data.Common;

namespace StoreManagement.Dal
{
    public class OperationRepository : DbContext, IOperationRepository
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

        public OperationRepository()
        {
            _Context = new StoreManagementEntities();
        }

        public long Count()
        {
            throw new NotSupportedException();
        }

        public void Create(Operation add)
        {
            throw new NotSupportedException();
        }

        public void Delete(Operation delete)
        {
            throw new NotSupportedException();
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            var conn = _Context.Database.Connection;
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    DbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        data.Load(reader);
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return data;
        }

        public Operation Get(Expression<Func<Operation, bool>> condition)
        {
            throw new NotSupportedException();
        }

        public IList<Operation> GetAll()
        {
            return _Context.Operations.ToList();
        }

        public void Update(Operation update)
        {
            throw new NotSupportedException();
        }
    }
}
