using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IWristSizeService
    {
        Task AddAsync(WristSizeDTO item);
        Task AddRangeAsync(IEnumerable<WristSizeDTO> items);

        ValueTask<WristSizeDTO> ReadAsync(int id);
        Task<WristSizeDTO> ReadAsync(Func<WristSizeDTO, bool> predicate);
        IEnumerable<WristSizeDTO> ReadAll(Func<WristSizeDTO, bool> predicate);

        void Update(WristSizeDTO item);
        void UpdateRange(IEnumerable<WristSizeDTO> items);

        void Delete(WristSizeDTO item);
        void DeleteRange(IEnumerable<WristSizeDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}