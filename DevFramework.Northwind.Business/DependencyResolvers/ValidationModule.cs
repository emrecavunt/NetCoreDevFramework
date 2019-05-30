using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.DependencyResolvers
{
    public static class ValidationModule
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Product>,ProductValidator>();

        }

    }
}
