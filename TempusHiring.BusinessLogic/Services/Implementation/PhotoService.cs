using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Entities;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task AddAsync(PhotoDTO photo)
        {
            var photoEntity = _mapper.Map<Photo>(photo);
            return _repository.AddAsync(photoEntity);
        }

        public Task AddRangeAsync(IEnumerable<PhotoDTO> photos)
        {
            var photoEntities = _mapper.Map<IEnumerable<Photo>>(photos);
            return _repository.AddRangeAsync(photoEntities);
        }

        public PhotoDTO ReadFirst(int watchId)
        {
            return ReadAll(watchId).First();
        }

        public IEnumerable<PhotoDTO> ReadAll(int watchId)
        {
            var photo = _repository.ReadAll(_ => _.WatchId == watchId).AsEnumerable();
            var photoDto = _mapper.Map<IEnumerable<PhotoDTO>>(photo);
            return photoDto;
        }

        public void Update(PhotoDTO photo)
        {
            UpdateRange(new[] {photo});
        }

        public void UpdateRange(IEnumerable<PhotoDTO> photos)
        {
            var photoIdentifiers = photos.Select(_ => _.Id).ToList();
            var existingPhotoEntities = _repository.ReadAll(_ => photoIdentifiers.Contains(_.Id))
                .ToList();

            if (photoIdentifiers.Count != existingPhotoEntities.Count)
            {
                var notFoundedIdentifiers = photoIdentifiers.Where(_ => existingPhotoEntities.All(x => x.Id != _)).ToList();
                var errorMessage = $"No identifiers found: {string.Join(" ", notFoundedIdentifiers)}";
                throw new Exception(errorMessage);
            }

            foreach (var item in existingPhotoEntities)
            {
                var model = photos.First(_ => _.Id == item.Id);
                item.Path = model.Path;
                item.WatchId = model.WatchId;
            }
        }

        public void Delete(int photoId)
        {
            DeleteRange(new[] { photoId });
        }

        public void DeleteRange(IEnumerable<int> photoIds)
        {
            var identifiersList = photoIds.ToList();
            var entities = _repository.ReadAll(_ => identifiersList.Contains(_.Id)).ToList();

            if (entities.Count != identifiersList.Count)
            {
                var notFoundedIdentifiers = identifiersList.Where(_ => entities.All(x => x.Id != _));
                var errorMessage = $"No identifiers found: {string.Join(" ", notFoundedIdentifiers)}";
                throw new Exception(errorMessage);
            }

            _repository.DeleteRange(entities);
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
