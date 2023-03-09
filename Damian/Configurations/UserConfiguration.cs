using Domian.Models;
using Domian.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    FirstName = "Dilshod",
                    LastName = "Abdijabbarov",
                    Login = "admin",
                    Password = "admin",
                    Role = RoleEnum.Admin,
                    isDelete = false,
                    Token=""
                },
                new User
                {
                    Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    FirstName = "Ali",
                    LastName = "Valiyev",
                    Login = "user",
                    Password = "user",
                    Role = RoleEnum.User,
                    isDelete = false,
                    Token = ""
                });                
        }
    }
}
