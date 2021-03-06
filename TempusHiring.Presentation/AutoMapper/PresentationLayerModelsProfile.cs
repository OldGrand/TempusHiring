﻿using System.Linq;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.AccountViewModels;
using TempusHiring.Presentation.Models.ViewModels.BodyMaterial;
using TempusHiring.Presentation.Models.ViewModels.Color;
using TempusHiring.Presentation.Models.ViewModels.GlassMaterial;
using TempusHiring.Presentation.Models.ViewModels.Manufacturer;
using TempusHiring.Presentation.Models.ViewModels.Mechanism;
using TempusHiring.Presentation.Models.ViewModels.Order;
using TempusHiring.Presentation.Models.ViewModels.ShoppingCart;
using TempusHiring.Presentation.Models.ViewModels.Strap;
using TempusHiring.Presentation.Models.ViewModels.StrapMaterial;
using TempusHiring.Presentation.Models.ViewModels.Watch;
using TempusHiring.Presentation.Models.ViewModels.WristSize;

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

            CreateMap<RegisterDTO, RegisterViewModel>()
                .ForMember(_ => _.Email, x => x.MapFrom(_ => _.UserName))
                .ReverseMap();
            
            CreateMap<ResetPasswordDTO, ResetPasswordViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<ShoppingCartDTO, ShoppingCartViewModel>().ReverseMap();
            CreateMap<OrderSummaryDTO, OrderSummaryViewModel>().ReverseMap();
            CreateMap<OrderWatchLinkDTO, OrderWatchLinkViewModel>().ReverseMap();
            CreateMap<PriceRangeDTO, PriceRangeViewModel>().ReverseMap();
            CreateMap<StrapDTO, StrapViewModel>().ReverseMap();
            
            CreateMap<PhotoDTO, PhotoViewModel>().ReverseMap();
            CreateMap<Filter, FilterViewModel>().ReverseMap();

            CreateMap<BodyMaterialDTO, BodyMaterialViewModel>().ReverseMap();
            CreateMap<BodyMaterialDTO, CreateBodyMaterialViewModel>().ReverseMap();
            CreateMap<BodyMaterialDTO, EditBodyMaterialViewModel>().ReverseMap();

            CreateMap<ColorDTO, ColorViewModel>().ReverseMap();
            CreateMap<ColorDTO, CreateColorViewModel>().ReverseMap();
            CreateMap<ColorDTO, EditColorViewModel>().ReverseMap();

            CreateMap<GlassMaterialDTO, GlassMaterialViewModel>().ReverseMap();
            CreateMap<GlassMaterialDTO, CreateGlassMaterialViewModel>().ReverseMap();
            CreateMap<GlassMaterialDTO, EditGlassMaterialViewModel>().ReverseMap();

            CreateMap<ManufacturerDTO, ManufacturerViewModel>().ReverseMap();
            CreateMap<ManufacturerDTO, CreateManufacturerViewModel>().ReverseMap();
            CreateMap<ManufacturerDTO, EditManufacturerViewModel>().ReverseMap();

            CreateMap<WristSizeDTO, WristSizeViewModel>().ReverseMap();
            CreateMap<WristSizeDTO, CreateWristSizeViewModel>().ReverseMap();
            CreateMap<WristSizeDTO, EditWristSizeViewModel>().ReverseMap();

            CreateMap<StrapMaterialDTO, StrapMaterialViewModel>().ReverseMap();
            CreateMap<StrapMaterialDTO, CreateStrapMaterialViewModel>().ReverseMap();
            CreateMap<StrapMaterialDTO, EditStrapMaterialViewModel>().ReverseMap();

            CreateMap<MechanismDTO, MechanismViewModel>().ReverseMap();
            CreateMap<MechanismDTO, CreateMechanismViewModel>().ReverseMap();
            CreateMap<MechanismDTO, EditMechanismViewModel>().ReverseMap();

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
            CreateMap<WatchDTO, CreateWatchViewModel>().ReverseMap();
            CreateMap<WatchDTO, EditWatchViewModel>().ReverseMap();

            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            CreateMap<OrderDTO, CreateOrderViewModel>().ReverseMap();
            CreateMap<OrderDTO, EditOrderViewModel>().ReverseMap();
            //TODO fix this shit
            CreateMap<PagedResult<WatchDTO>, PagedResult<WatchViewModel>>().ReverseMap();
            CreateMap<PagedResult<BodyMaterialDTO>, PagedResult<BodyMaterialViewModel>>().ReverseMap();
            CreateMap<PagedResult<ColorDTO>, PagedResult<ColorViewModel>>().ReverseMap();
            CreateMap<PagedResult<GlassMaterialDTO>, PagedResult<GlassMaterialViewModel>>().ReverseMap();
            CreateMap<PagedResult<ManufacturerDTO>, PagedResult<ManufacturerViewModel>>().ReverseMap();
            CreateMap<PagedResult<WristSizeDTO>, PagedResult<WristSizeViewModel>>().ReverseMap();
            CreateMap<PagedResult<StrapMaterialDTO>, PagedResult<StrapMaterialViewModel>>().ReverseMap();
            CreateMap<PagedResult<MechanismDTO>, PagedResult<MechanismViewModel>>().ReverseMap();
        }
    }
}