using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IStrapService
    {
        Task AddAsync(StrapDTO item);
        Task AddRangeAsync(IEnumerable<StrapDTO> items);

        ValueTask<StrapDTO> ReadAsync(int id);
        Task<StrapDTO> ReadAsync(Func<StrapDTO, bool> predicate);
        IEnumerable<StrapDTO> ReadAll(Func<StrapDTO, bool> predicate);

        void Update(StrapDTO item);
        void UpdateRange(IEnumerable<StrapDTO> items);

        void Delete(StrapDTO item);
        void DeleteRange(IEnumerable<StrapDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}