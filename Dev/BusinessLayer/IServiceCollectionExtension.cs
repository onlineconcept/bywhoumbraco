using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLayer
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IStyleService, StyleService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}
