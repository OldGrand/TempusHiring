using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.Presentation.Models.AccountViewModels;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Admin;

namespace TempusHiring.Presentation.AutoMapper
{
    public class PresentationLayerModelsProfile : Profile
    {
        public PresentationLayerModelsProfile()
        {
            CreateMap<ResetPasswordDTO, ResetPasswordViewModel>().ReverseMap();
            CreateMap<ExternalRegisterViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<LoginViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<RegisterViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<WatchDTO, WatchViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<ShoppingCartDTO, ShoppingCartViewModel>().ReverseMap();
            CreateMap<OrderSummaryDTO, OrderSummaryViewModel>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            CreateMap<OrderWatchLinkDTO, OrderWatchLinkViewModel>().ReverseMap();
            CreateMap<PriceRangeDTO, PriceRangeViewModel>().ReverseMap();
            CreateMap<PagedResult<WatchDTO>, PagedResult<WatchViewModel>>().ReverseMap();

            CreateMap<BodyMaterialDTO, BodyMaterialViewModel>().ReverseMap();
            CreateMap<ColorDTO, ColorViewModel>().ReverseMap();
            CreateMap<GlassMaterialDTO, GlassMaterialViewModel>().ReverseMap();
            CreateMap<ManufacturerDTO, ManufacturerViewModel>().ReverseMap();
            CreateMap<MechanismDTO, MechanismViewModel>().ReverseMap();
            CreateMap<StrapDTO, StrapViewModel>().ReverseMap();
            CreateMap<StrapMaterialDTO, StrapMaterialViewModel>().ReverseMap();
            CreateMap<WristSizeDTO, WristSizeViewModel>().ReverseMap();
        }
    }
}
