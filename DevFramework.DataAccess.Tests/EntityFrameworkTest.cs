using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Tests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        private IProductDal _productDal;

        public EntityFrameworkTest(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            var result = _productDal.GetList();

            Assert.AreEqual(85, result.Count);

        }
        [TestMethod]
        public void Get_all_with_paramater_returns_filtered_products()
        {
            var result = _productDal.GetList(p => p.ProductName.Contains("a"));

            Assert.AreEqual(4, result.Count);

        }
    }
}
