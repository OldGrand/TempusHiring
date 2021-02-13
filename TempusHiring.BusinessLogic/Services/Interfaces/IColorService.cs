using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IColorService
    {
        Task AddAsync(ColorDTO item);
        Task AddRangeAsync(IEnumerable<ColorDTO> items);

        ValueTask<ColorDTO> ReadAsync(int id);
        Task<ColorDTO> ReadAsync(Func<ColorDTO, bool> predicate);
        IEnumerable<ColorDTO> ReadAll(Func<ColorDTO, bool> predicate);

        void Update(ColorDTO item);
        void UpdateRange(IEnumerable<ColorDTO> items);

        void Delete(ColorDTO item);
        void DeleteRange(IEnumerable<ColorDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
