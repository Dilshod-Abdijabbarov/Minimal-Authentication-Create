using AutoMapper;
using Contract;
using Domian.DTOs.User;
using Domian.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryMenager repositoryMenager;
        private readonly IOptions<AppSettings> appSettings;
        private readonly JwtSecurityTokenHandler securityTokenHandler;
        private readonly  IMapper mapper;

        public UserController(IRepositoryMenager repositoryMenager,IOptions<AppSettings> appSettings,IMapper mapper)
        {
            this.repositoryMenager = repositoryMenager ?? throw new ArgumentNullException(nameof(repositoryMenager));
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            securityTokenHandler = new JwtSecurityTokenHandler();
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserAuthInfoDTO>> LoginAsyn([FromBody] UserCradentials userCradentials,CancellationToken cancellationToken)
        {
            UserAuthInfoDTO userAuthInfoDTO = new UserAuthInfoDTO();
            if (userCradentials == null)
                return BadRequest("No Data");
           
         User user= await repositoryMenager.User.LoginAsync(userCradentials.Login,userCradentials.Password,false,cancellationToken);

            if (user != null)
            {
                var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity
                    (
                        new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.GivenName, user.FirstName),
                            new Claim(ClaimTypes.Name, user.LastName),                          
                            new Claim(ClaimTypes.Role, user.Role.ToString())
                        }
                     ),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                };
               var securityToken =securityTokenHandler.CreateToken(tokenDescription);
                userAuthInfoDTO.Token=securityTokenHandler.WriteToken(securityToken);
                userAuthInfoDTO.UserDetails = mapper.Map<UserDTO>(user);
            }

            if(string.IsNullOrEmpty(userAuthInfoDTO?.Token))
            {
                return BadRequest("Error login or passmword");  
            }
           return Ok(userAuthInfoDTO);   
        }
    }
}
