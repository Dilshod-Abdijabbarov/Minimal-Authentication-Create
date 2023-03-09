using Contract;
using Domian.RepositoryContexts;
using Domian.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryMenager : IRepositoryMenager
    {
        private readonly RepositoryContext repositoryContext;
        private IUserRepository userRepository;
        public RepositoryMenager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(repositoryContext);
                }
                return userRepository;
            }
        }
        public Task SaveAsync() => repositoryContext.SaveChangesAsync();
    }
}
