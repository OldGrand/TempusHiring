using System;
using System.Threading.Tasks;
using TempusHiring.DataAccess.Core;

namespace TempusHiring.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public TempusHiringDbContext DbContext { get; }

        Task<int> CommitAsync();
        int Commit();
    }
}
