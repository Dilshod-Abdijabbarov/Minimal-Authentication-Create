using Domian.Configurations;
using Domian.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.RepositoryContexts
{
    public  class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<User> User { get; set; }
    }
}
