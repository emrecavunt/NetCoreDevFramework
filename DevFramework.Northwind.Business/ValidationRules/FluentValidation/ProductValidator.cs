using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 25);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);

            //RuleFor(p => p.ProductName).Must(StartsWithA);
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        } 
    }
}
