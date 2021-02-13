using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Implementation.Common;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Entities;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class BodyMaterialService : CrudService<BodyMaterial, BodyMaterialDTO>, IBodyMaterialService
    {
        public BodyMaterialService(IRepository<BodyMaterial> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
        {
        }
    }
}
