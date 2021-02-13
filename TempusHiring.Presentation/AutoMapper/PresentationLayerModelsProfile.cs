using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.Presentation.Models.AccountViewModels;
using TempusHiring.Presentation.Models.ViewModels;

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
        }
    }
}
