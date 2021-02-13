using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IMechanismService
    {
        Task AddAsync(MechanismDTO item);
        Task AddRangeAsync(IEnumerable<MechanismDTO> items);

        ValueTask<MechanismDTO> ReadAsync(int id);
        Task<MechanismDTO> ReadAsync(Func<MechanismDTO, bool> predicate);
        IEnumerable<MechanismDTO> ReadAll(Func<MechanismDTO, bool> predicate);

        void Update(MechanismDTO item);
        void UpdateRange(IEnumerable<MechanismDTO> items);

        void Delete(MechanismDTO item);
        void DeleteRange(IEnumerable<MechanismDTO> items);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}