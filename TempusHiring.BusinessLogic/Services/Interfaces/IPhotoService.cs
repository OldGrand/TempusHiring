using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IPhotoService
    {
        Task AddAsync(PhotoDTO photo);
        Task AddRangeAsync(IEnumerable<PhotoDTO> photos);

        PhotoDTO ReadFirst(int watchId);
        IEnumerable<PhotoDTO> ReadAll(int watchId);

        void Update(PhotoDTO photo);
        void UpdateRange(IEnumerable<PhotoDTO> photos);

        void Delete(int photoId);
        void DeleteRange(IEnumerable<int> photoIds);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
