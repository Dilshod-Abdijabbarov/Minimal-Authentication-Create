using Contract;
using Domian.RepositoryContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract  class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext repositoryContext;
        private readonly DbSet<T> dbSet;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
            this.dbSet = repositoryContext.Set<T>();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tracking) =>
            !tracking ?
            dbSet.Where(expression):
            dbSet.Where(expression);
        
    }
}
