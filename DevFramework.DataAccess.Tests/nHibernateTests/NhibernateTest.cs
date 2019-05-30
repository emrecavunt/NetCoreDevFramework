using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.DataAccess.Tests.nHibernateTests
{
    [TestClass]
    public class NhibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal efProductDal = new NhProductDal(new SqlServerHelper());
            var result = efProductDal.GetList();

            Assert.AreEqual(85, result.Count);

        }
        [TestMethod]
        public void Get_all_with_paramater_returns_filtered_products()
        {
            NhProductDal efProductDal = new NhProductDal(new SqlServerHelper());
            var result = efProductDal.GetList(p => p.ProductName.Contains("a"));

            Assert.AreEqual(4, result.Count);

        }
    }
}
