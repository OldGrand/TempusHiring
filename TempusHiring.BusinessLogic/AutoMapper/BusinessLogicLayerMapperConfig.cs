using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.AutoMapper
{
    public static class BusinessLogicLayerMapperConfig
    {
        public static IConfigurationProvider GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BodyMaterial, BodyMaterialDTO>().ReverseMap();
                cfg.CreateMap<Color, ColorDTO>().ReverseMap();
                cfg.CreateMap<GlassMaterial, GlassMaterialDTO>().ReverseMap();
                cfg.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
                cfg.CreateMap<Mechanism, MechanismDTO>().ReverseMap();
                cfg.CreateMap<Strap, StrapDTO>().ReverseMap();
                cfg.CreateMap<StrapMaterial, StrapMaterialDTO>().ReverseMap();
                cfg.CreateMap<WristSize, WristSizeDTO>().ReverseMap();
                cfg.CreateMap<Watch, WatchDTO>().ReverseMap();
            });
        }
    }
}
