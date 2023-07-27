using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zeal_education.Data;
using Zeal_education.Models;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private zeal_educationContext _context;
        private IConfiguration _configuration;
        public static User systemuser;
        private static User newuser;
        private static string verifi_OTP;


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
                    return BadRequest(ResponseMessage.error("Password does not match"));
                }
                var checkuser = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.IsActive == true);
                if (checkuser == null)
                {
                    newuser = new User
                    {
                        Email = user.Email,
                        Password = Hash(user.Password),
                        Dob = user.Dob,
                        FullName = user.FullName,
                    };
                    
                    verifi_OTP = CreateRandomString();
                    string body = "Your code verify is: " + verifi_OTP;
                    sendEmail("Verifry Email", body, newuser.Email);

                    return Ok(ResponseMessage.ok("please verify your email. ", newuser));
                }
                else
                {
                    return BadRequest(ResponseMessage.error("Email has already existed "));
                }

            }
            catch(Exception ex) 
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }

        private string CreateRandomString()
        {
            Random RNG = new Random();
            int length = 6;
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(RNG.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }

        [HttpPost("verify")]
        public IActionResult Verify(string otp)
        {
            if(otp == verifi_OTP)
            {
                _context.Users.Add(newuser);
                _context.SaveChanges();
                return Ok(ResponseMessage.ok("Create account sucessfully ", newuser));
            }
            return BadRequest(ResponseMessage.error("Invalid code"));
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            if (user != null)
            {
                systemuser = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == Hash(user.Password) && x.IsActive == true);

                if (systemuser != null)
                {
                    string Token = createToken(systemuser);
                    return Ok(ResponseMessage.ok("Login Account successfully. ", Token));
                }
                else
                {
                    return BadRequest(ResponseMessage.error("Email or Password not valid. "));
                }
            }
            else
            {
                return BadRequest(ResponseMessage.error("Email or Password not valid. "));
            }
        }
        private string createToken(User user)
        {
            var userrole = _context.Roles.SingleOrDefault(x => x.Id == user.RoleId && x.IsActive == true);
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
        private string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        private void sendEmail(string subject, string body, string to)
        {
            string fromMail = "zealeducationa@gmail.com";
            string fromPassword = "rbdrmqhehyyzdvuq";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(to));
            message.Body = body;
            message.IsBodyHtml = false;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}
