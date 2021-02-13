using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.AutoMapper
{
    public class BusinessLogicLayerModelsProfile : Profile
    {
        public BusinessLogicLayerModelsProfile()
        {
            CreateMap<User, RegisterDTO>().ForMember(_ => _.Password, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
