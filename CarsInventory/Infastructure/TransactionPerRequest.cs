using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarsInventory.DataContext;
using CarsInventory.Infastructure.Tasks;

namespace CarsInventory.Infastructure
{
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private HttpContextBase _httpContext;
        private InventoryDb _dbContext;

        public TransactionPerRequest(InventoryDb dbContext,HttpContextBase httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }
        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items["_Transaction"] =
                _dbContext.Database.BeginTransaction((System.Data.IsolationLevel..ReadCommitted));
        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_httpContext.Items["_Transaction"];

            if (_httpContext.Items["_Error"] != null)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}