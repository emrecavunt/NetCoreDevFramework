using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.DependencyResolvers
{
    public class AutoMapperModule
    {
        private MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetType().Assembly);
            });
        }
    }
}
