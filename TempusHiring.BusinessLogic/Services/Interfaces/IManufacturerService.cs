using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task AddAsync(ManufacturerDTO item);
        Task AddRangeAsync(IEnumerable<ManufacturerDTO> items);

        ValueTask<ManufacturerDTO> ReadAsync(int id);
        Task<ManufacturerDTO> ReadAsync(Func<ManufacturerDTO, bool> predicate);
        IEnumerable<ManufacturerDTO> ReadAll(Func<ManufacturerDTO, bool> predicate);

        void Update(ManufacturerDTO item);
        void UpdateRange(IEnumerable<ManufacturerDTO> items);

        void Delete(ManufacturerDTO item);
        void DeleteRange(IEnumerable<ManufacturerDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}