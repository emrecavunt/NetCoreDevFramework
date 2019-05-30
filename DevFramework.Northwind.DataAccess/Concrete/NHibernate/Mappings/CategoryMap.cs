using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap: ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
 