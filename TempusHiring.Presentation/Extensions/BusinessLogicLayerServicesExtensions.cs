using Microsoft.Extensions.DependencyInjection;
using TempusHiring.BusinessLogic.Services;
using TempusHiring.BusinessLogic.Services.Implementation;
using TempusHiring.BusinessLogic.Services.Implementation.Common;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.BusinessLogic.Services.Interfaces.Common;

namespace TempusHiring.Presentation.Extensions
{
    public static class BusinessLogicLayerServicesExtensions
    {
        public static void AddBusinessLogicLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBodyMaterialService, BodyMaterialService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IGlassMaterialService, GlassMaterialService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IMechanismService, MechanismService>();
            services.AddScoped<IStrapMaterialService, StrapMaterialService>();
            services.AddScoped<IStrapService, StrapService>();
            services.AddScoped<IWristSizeService, WristSizeService>();
            
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<,>));
        }
    }
}
