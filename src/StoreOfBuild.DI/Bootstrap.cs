﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ApplicationDbContext>(options =>  options.UseSqlServer(connectionString));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(CategoryService));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}

