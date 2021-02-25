using System.Linq;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.AccountViewModels;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Admin;
using TempusHiring.Presentation.Models.ViewModels.BodyMaterial;

namespace TempusHiring.Presentation.AutoMapper
{
    public class PresentationLayerModelsProfile : Profile
    {
        public PresentationLayerModelsProfile()
        {
            CreateMap<LoginDTO, LoginViewModel>()
                .ForMember(dst => dst.Email, src => src.MapFrom(_ => _.UserName))
                .ReverseMap();

            CreateMap<ExternalRegisterViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<LoginViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<RegisterViewModel, UserDTO>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(_ => _.Email))
                .ReverseMap();

            CreateMap<WatchDTO, WatchViewModel>()
                .BeforeMap((x, y) =>
                {
                    if (x.Photos is not null && x.Photos.Any())
                    {
                        x.PreviewPhoto = x.Photos.First().Path;
                        return;
                    }
                    x.PreviewPhoto = string.Empty;
                })
                .ReverseMap();

            CreateMap<RegisterDTO, RegisterViewModel>()
                .ForMember(_ => _.Email, x => x.MapFrom(_ => _.UserName))
                .ReverseMap();
            
            CreateMap<ResetPasswordDTO, ResetPasswordViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<ShoppingCartDTO, ShoppingCartViewModel>().ReverseMap();
            CreateMap<OrderSummaryDTO, OrderSummaryViewModel>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            CreateMap<OrderWatchLinkDTO, OrderWatchLinkViewModel>().ReverseMap();
            CreateMap<PriceRangeDTO, PriceRangeViewModel>().ReverseMap();
            CreateMap<ColorDTO, ColorViewModel>().ReverseMap();
            CreateMap<GlassMaterialDTO, GlassMaterialViewModel>().ReverseMap();
            CreateMap<ManufacturerDTO, ManufacturerViewModel>().ReverseMap();
            CreateMap<MechanismDTO, MechanismViewModel>().ReverseMap();
            CreateMap<StrapDTO, StrapViewModel>().ReverseMap();
            CreateMap<StrapMaterialDTO, StrapMaterialViewModel>().ReverseMap();
            CreateMap<WristSizeDTO, WristSizeViewModel>().ReverseMap();
            CreateMap<PhotoDTO, PhotoViewModel>().ReverseMap();
            CreateMap<Filter, FilterViewModel>().ReverseMap();

            CreateMap<BodyMaterialDTO, BodyMaterialViewModel>().ReverseMap();
            CreateMap<BodyMaterialDTO, CreateBodyMaterialViewModel>().ReverseMap();
            CreateMap<BodyMaterialDTO, EditBodyMaterialViewModel>().ReverseMap();

            //TODO fix this shit
            CreateMap<PagedResult<WatchDTO>, PagedResult<WatchViewModel>>().ReverseMap();
            CreateMap<PagedResult<BodyMaterialDTO>, PagedResult<BodyMaterialViewModel>>().ReverseMap();
        }
    }
}
