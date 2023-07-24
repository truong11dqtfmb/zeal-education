using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zeal_education.Data;
using Zeal_education.Models;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private zeal_educationContext _context;
        private IConfiguration _configuration;
        public static User systemuser;

        public AuthController(zeal_educationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("registor")]
        public IActionResult Registor(RegistorModel user)
        {
            try
            {
                if (user.Password != user.ConfirmPassword)
                {
                    return BadRequest("Password does not match");
                }
                var checkuser = _context.Users.SingleOrDefault(x => x.Email == user.Email);
                if (checkuser == null)
                {
                    var newuser = new User
                    {
                        Email = user.Email,
                        Password = user.Password,
                        Dob = user.Dob,
                        FullName = user.FullName,
                    };
                    _context.Users.Add(newuser);
                    _context.SaveChanges();
                    return Ok("registor successfully");

                }
                else
                {
                    return BadRequest("Email has already used");
                }

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            if (user != null)
            {
                systemuser = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);

                if (systemuser != null)
                {
                    string Token = createToken(systemuser);
                    return Ok(Token);
                }
                else
                {
                    return BadRequest("Invalid username password");
                }
            }
            else
            {
                return BadRequest("null user");
            }
        }
        private string createToken(User user)
        {
            var userrole = _context.Roles.SingleOrDefault(x => x.Id == user.RoleId);
            var rolename = userrole.RoleName;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, rolename)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
