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
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ISubCategoryDal, SubCategoryDal>();
            services.AddScoped<ISubCategoryService, SubCategoryManager>();

            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            return services;
        }
    }
}
