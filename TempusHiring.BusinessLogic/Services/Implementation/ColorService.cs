using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Services.Implementation.Common;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Entities;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class ColorService : CrudService<Color, ColorDTO>, IColorService
    {
        public ColorService(IRepository<Color> repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
