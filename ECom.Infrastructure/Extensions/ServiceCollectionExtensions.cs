﻿using ECom.Application.Interfaces.CacheRepositories;
using ECom.Application.Interfaces.Contexts;
using ECom.Application.Interfaces.Repositories;
using ECom.Infrastructure.CacheRepositories;
using ECom.Infrastructure.DbContexts;
using ECom.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}