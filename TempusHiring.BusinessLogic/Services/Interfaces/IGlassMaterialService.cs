using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IGlassMaterial
    {
        Task AddAsync(GlassMaterialDTO item);
        Task AddRangeAsync(IEnumerable<GlassMaterialDTO> items);

        ValueTask<GlassMaterialDTO> ReadAsync(int id);
        Task<GlassMaterialDTO> ReadAsync(Func<GlassMaterialDTO, bool> predicate);
        IEnumerable<GlassMaterialDTO> ReadAll(Func<GlassMaterialDTO, bool> predicate);

        void Update(GlassMaterialDTO item);
        void UpdateRange(IEnumerable<GlassMaterialDTO> items);

        void Delete(GlassMaterialDTO item);
        void DeleteRange(IEnumerable<GlassMaterialDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
