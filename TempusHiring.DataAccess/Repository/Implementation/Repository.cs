using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.Repository.Interfaces;

namespace TempusHiring.DataAccess.Repository.Implementation
{
    public class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        private readonly TempusHiringDbContext _context;
        private readonly DbSet<TSource> _set;

        public Repository(TempusHiringDbContext context)
        {
            _context = context;
            _set = _context.Set<TSource>();
        }

        public Task AddAsync(TSource item)
        {
            return AddRangeAsync(new[] { item });
        }

        public Task AddRangeAsync(IEnumerable<TSource> items)
        {
            return _set.AddRangeAsync(items);
        }

        public ValueTask<TSource> ReadAsync(int id)
        {
            return _set.FindAsync(id);
        }

        public Task<TSource> ReadAsync(Func<TSource, bool> predicate)
        {
            var methodCallExpression = Expression.Call(predicate.Method);
            var expression = Expression.Lambda<Func<TSource, bool>>(methodCallExpression);
            return _set.FirstOrDefaultAsync(expression);
        }

        public IQueryable<TSource> ReadAll(Func<TSource, bool> predicate)
        {
            return _set.Where(predicate).AsQueryable();
        }

        public void Update(TSource item)
        {
            UpdateRange(new[] { item });
        }

        public void UpdateRange(IEnumerable<TSource> items)
        {
            _context.Entry(items).State = EntityState.Modified;
        }

        public void Delete(TSource item)
        {
            DeleteRange(new[] { item });
        }

        public void DeleteRange(IEnumerable<TSource> items)
        {
            _set.RemoveRange(items);
        }
    }
}
