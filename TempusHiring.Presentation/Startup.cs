using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TempusHiring.BusinessLogic.AutoMapper;
using TempusHiring.Common;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.Entities;
using TempusHiring.Presentation.AutoMapper;
using TempusHiring.Presentation.Extensions;

namespace TempusHiring.Presentation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TempusHiringDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddRouting(option =>
            {
                //option.LowercaseQueryStrings = true;
                //option.LowercaseUrls = true;
            });

            services.AddAutoMapper(typeof(PresentationLayerModelsProfile), typeof(BusinessLogicLayerModelsProfile));
            services.AddUnitOfWorkAndRepository();
            services.AddBusinessLogicLayerServices();

            services.AddIdentity<User, IdentityRole<int>>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 8;

                config.User.RequireUniqueEmail = true;
                config.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<TempusHiringDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
                config.LogoutPath = "/Account/Logout";
            });

            services.AddAuthentication()
                .AddFacebook(config =>
                {
                    config.AppId = _configuration["Authentication:Facebook:AppId"];
                    config.AppSecret = _configuration["Authentication:Facebook:AppSecret"];
                })
                .AddVkontakte(config =>
                {
                    config.ClientId = _configuration["Authentication:VK:AppId"];
                    config.ClientSecret = _configuration["Authentication:VK:AppSecret"];
                })
                .AddGoogle(config =>
                {
                    config.ClientId = _configuration["Authentication:Google:AppId"];
                    config.ClientSecret = _configuration["Authentication:Google:AppSecret"];
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy(ClaimRoles.Admin, builder =>
                {
                    builder.RequireRole(ClaimRoles.Admin);
                });

                config.AddPolicy(ClaimRoles.Manager, builder =>
                {
                    builder.RequireRole(ClaimRoles.Manager);
                });

                config.AddPolicy(ClaimRoles.User, builder =>
                {
                    builder.RequireRole(ClaimRoles.User);
                });
            });

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(config =>
            {
                config.Cookie.IsEssential = true;
                config.IdleTimeout = TimeSpan.FromHours(2);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}