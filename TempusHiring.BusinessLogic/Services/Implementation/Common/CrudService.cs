using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces.Common;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation.Common
{
    public class CrudService<TEntity, TModel> : ICrudService<TModel> where TEntity : class where TModel : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            return _repository.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TModel> models)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(models);
            return _repository.AddRangeAsync(entities);
        }

        public async ValueTask<TModel> ReadAsync(int id)
        {
            var source = await _repository.ReadAsync(id);
            var result = _mapper.Map<TModel>(source);
            return result;
        }

        public IEnumerable<TModel> ReadAll(int pageNum, int itemsOnPage)
        {
            var source = _repository.ReadAll()
                                                     .GetPaged(pageNum, itemsOnPage)
                                                     .Result;

            var result = _mapper.Map<IEnumerable<TModel>>(source);
            return result;
        }

        public IEnumerable<TModel> ReadAll()
        {
            var source = _repository.ReadAll()
                                                     .AsEnumerable();

            var result = _mapper.Map<IEnumerable<TModel>>(source);
            return result;
        }
        
        public void Update(TModel item)
        {
            UpdateRange(new[] { item });
        }

        public void UpdateRange(IEnumerable<TModel> items)
        {
            var result = _mapper.Map<IEnumerable<TEntity>>(items);
            _repository.UpdateRange(result);
        }

        public void Delete(TModel item)
        {
            DeleteRange(new[] { item });
        }

        public void DeleteRange(IEnumerable<TModel> items)
        {
            var result = _mapper.Map<IEnumerable<TEntity>>(items);
            _repository.DeleteRange(result);
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
