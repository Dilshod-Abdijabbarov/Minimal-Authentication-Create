using Authentication.Helpers;
using Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryMenager repositoryMenager;
        public OrderController(IRepositoryMenager repositoryMenager)
        {
            this.repositoryMenager = repositoryMenager;
        }

        [Authorize(Roles =CustomRole.Admin_Role)]
        [HttpPost("Admin Role")]
        public string  Admin_Text()
        {
            return "Admin Role";
        } 
        
        [Authorize(Roles =CustomRole.User_Role)]
        [HttpPost("User Role")]
        public string  User_Text()
        {
            return "User Role";
        }

        [Authorize(Roles = CustomRole.All_Role)]
        [HttpPost("All Role")]
        public string All_Text()
        {
            return "All Role";
        }
    }
}
