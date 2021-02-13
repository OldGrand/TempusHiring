using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempusHiring.DataAccess.Repository.Interfaces
{
    public interface IRepository<TSource> where TSource : class
    {
        Task AddAsync(TSource item);
        Task AddRangeAsync(IEnumerable<TSource> items);

        ValueTask<TSource> ReadAsync(int id);
        Task<TSource> ReadAsync(Func<TSource, bool> predicate);
        IQueryable<TSource> ReadAll(Func<TSource, bool> predicate);
        IQueryable<TSource> ReadAll();

        void Update(TSource item);
        void UpdateRange(IEnumerable<TSource> items);

        void Delete(TSource item);
        void DeleteRange(IEnumerable<TSource> items);
    }
}