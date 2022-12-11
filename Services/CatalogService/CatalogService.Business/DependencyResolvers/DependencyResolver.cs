using CatalogService.Business.Abstract;
using CatalogService.Business.Concrete;
using CatalogService.DataAccess.Abstract;
using CatalogService.DataAccess.Concrete.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.DependencyResolvers
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddCustomDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();

            services.AddScoped<ISubCategoryService, SubCategoryManager>();
            services.AddScoped<ISubCategoryDal, SubCategoryDal>();

            return services;
        }
    }
}
