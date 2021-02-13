using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.AutoMapper
{
    public class BusinessLogicLayerModelsProfile : Profile
    {
        public BusinessLogicLayerModelsProfile()
        {
            CreateMap<User, RegisterDTO>().ForMember(_ => _.Password, opt => opt.Ignore())
                                          .ReverseMap();

            CreateMap<BodyMaterial, BodyMaterialDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<GlassMaterial, GlassMaterialDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            CreateMap<Mechanism, MechanismDTO>().ReverseMap();
            CreateMap<Strap, StrapDTO>().ReverseMap();
            CreateMap<StrapMaterial, StrapMaterialDTO>().ReverseMap();
            CreateMap<WristSize, WristSizeDTO>().ReverseMap();
        }
    }
}
