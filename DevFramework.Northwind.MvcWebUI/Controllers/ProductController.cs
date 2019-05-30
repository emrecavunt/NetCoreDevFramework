using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll().ToList()
            };
            return View(model);
        }
        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Telefon",
                QuantityPerUnit = "1",
                UnitPrice = 12
            });
            return "Added";
        }
    }
}