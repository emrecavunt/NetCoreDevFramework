using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NhibernateHelper _NhibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NhibernateHelper NhibernateHelper)
        {
            _NhibernateHelper = NhibernateHelper;
        }

        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _NhibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
