using Microsoft.Extensions.DependencyInjection;
using TempusHiring.DataAccess.Repository.Implementation;
using TempusHiring.DataAccess.Repository.Interfaces;
using TempusHiring.DataAccess.UnitOfWork.Implementation;
using TempusHiring.DataAccess.UnitOfWork.Interfaces;

namespace TempusHiring.Presentation.Extensions
{
    public static class DataAccessLayerServiceProvider
    {
        public static void AddUnitOfWorkAndRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
