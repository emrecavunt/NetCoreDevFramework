using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.DependencyResolvers
{
    public static partial class DIServiceModule
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IUserService, IUserService>();



            #endregion
        }
    }
}
