using Domian.RepositoryContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public  interface IRepositoryBase<T> where T : class
    {
        public IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool tracking);
    }
}
