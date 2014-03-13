
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Entity;
using POUM.DataLayer.Interface;


namespace POUM.DataLayer.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MovieDbContext DbContext = null;
        private bool disposed = false;

        public UnitOfWork()
        {
            DbContext = new MovieDbContext();
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

       

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public System.Data.Entity.DbContext Context
        {
            get { return DbContext; }
        }
    }
}
