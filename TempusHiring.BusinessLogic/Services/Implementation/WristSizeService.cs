using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Services.Implementation.Common;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Entities;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class WristSizeService : CrudService<WristSize, WristSizeDTO>, IWristSizeService
    {
        public WristSizeService(IRepository<WristSize> repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
