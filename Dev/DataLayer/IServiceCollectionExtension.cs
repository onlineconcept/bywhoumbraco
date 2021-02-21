using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IStyleRepository, StyleRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IMaterialRepository,MaterialRepository>();
            services.AddScoped<IResourceRepository,ResourceRepository>();
            
            
            return services;
        }
    }
}
