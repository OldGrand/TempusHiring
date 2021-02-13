using System;
using System.Threading.Tasks;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.DataAccess.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public TempusHiringDbContext DbContext { get; }

        public UnitOfWork(TempusHiringDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }
    }
}