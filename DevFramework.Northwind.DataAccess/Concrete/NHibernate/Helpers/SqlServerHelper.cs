using DevFramework.Core.DataAccess.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NhibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {

            return Fluently.Configure().Database(PostgreSQLConfiguration.PostgreSQL81
                .ConnectionString(c =>  c.Database("NorthwindDb"))).Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
