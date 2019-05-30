using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.DependencyResolvers
{
    public static class DIDataModule
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            #region repository

            services.AddScoped<DbContext, NorthwindContext>();
            services.AddSingleton(typeof(IQueryableRepository<>), typeof(EfQueryableRepository<>));
            //services.AddSingleton(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,DbContext>));

            services.AddScoped<NhibernateHelper, SqlServerHelper>();



            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IUserDal, EfUserDal>();

            #endregion
        }
    }
}
