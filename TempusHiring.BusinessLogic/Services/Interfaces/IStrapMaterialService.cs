using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IStrapMaterialService
    {
        Task AddAsync(StrapMaterialDTO item);
        Task AddRangeAsync(IEnumerable<StrapMaterialDTO> items);

        ValueTask<StrapMaterialDTO> ReadAsync(int id);
        Task<StrapMaterialDTO> ReadAsync(Func<StrapMaterialDTO, bool> predicate);
        IEnumerable<StrapMaterialDTO> ReadAll(Func<StrapMaterialDTO, bool> predicate);

        void Update(StrapMaterialDTO item);
        void UpdateRange(IEnumerable<StrapMaterialDTO> items);

        void Delete(StrapMaterialDTO item);
        void DeleteRange(IEnumerable<StrapMaterialDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}