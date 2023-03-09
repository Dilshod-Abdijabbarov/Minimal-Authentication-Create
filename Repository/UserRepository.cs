using Contract;
using Domian.RepositoryContexts;
using Domian.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User> LoginAsync(string login, string password, bool traking, CancellationToken cancellationToken = default) =>
            await FindByCondition(x => x.Login.Equals(login) && x.Password.Equals(password), traking)
            .SingleOrDefaultAsync(cancellationToken);
    }
}
