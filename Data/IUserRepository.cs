using Domian.RepositoryContexts;
using Domian.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> LoginAsync(string login, string password, bool traking, CancellationToken cancellationToken);
    }
}
