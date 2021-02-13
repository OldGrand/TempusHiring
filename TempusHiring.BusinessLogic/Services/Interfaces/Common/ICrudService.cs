using System.Collections.Generic;
using System.Threading.Tasks;

namespace TempusHiring.BusinessLogic.Services.Interfaces.Common
{
    public interface ICrudService<TModel> where TModel : class
    {
        Task AddAsync(TModel item);
        Task AddRangeAsync(IEnumerable<TModel> items);

        ValueTask<TModel> ReadAsync(int id);
        IEnumerable<TModel> ReadAll(int pageNum, int itemsOnPage);
        IEnumerable<TModel> ReadAll();

        void Update(TModel item);
        void UpdateRange(IEnumerable<TModel> items);

        void Delete(TModel item);
        void DeleteRange(IEnumerable<TModel> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
