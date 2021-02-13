using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class AdminService<TSource, TResult> : IAdminService<TSource, TResult> where TSource : class
    {
        private readonly IRepository<TSource> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IRepository<TSource> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddAsync(TSource item)
        {
            return _repository.AddAsync(item);
        }

        public Task AddRangeAsync(IEnumerable<TSource> items)
        {
            return _repository.AddRangeAsync(items);
        }

        public async ValueTask<TResult> ReadAsync(int id)
        {
            var source = await _repository.ReadAsync(id);
            var result = _mapper.Map<TResult>(source);
            return result;
        }

        public async Task<TResult> ReadAsync(Func<TSource, bool> predicate)
        {
            var source = await _repository.ReadAsync(predicate);
            var result = _mapper.Map<TResult>(source);
            return result;
        }

        public IEnumerable<TResult> ReadAll(Func<TSource, bool> predicate)
        {
            var source = _repository.ReadAll(predicate).AsEnumerable();
            var result = _mapper.Map<IEnumerable<TResult>>(source);
            return result;
        }

        public void Update(TSource item)
        {
            _repository.Update(item);
        }

        public void UpdateRange(IEnumerable<TSource> items)
        {
            _repository.UpdateRange(items);
        }

        public void Delete(TSource item)
        {
            _repository.Delete(item);
        }

        public void DeleteRange(IEnumerable<TSource> items)
        {
            _repository.DeleteRange(items);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.CommitAsync();
        }
    }
}
