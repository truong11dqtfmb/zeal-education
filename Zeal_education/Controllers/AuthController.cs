using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zeal_education.Data;
using Zeal_education.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;

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
                        Password = Common.Hash(user.Password),
                        Dob = user.Dob,
                        FullName = user.FullName,
                    };

                    verifi_OTP = CreateRandomString(6);
                    string body = "Your code verify is: " + verifi_OTP;
                    sendEmail("Verifry Email", body, newuser.Email);

                    return Ok(ResponseMessage.ok("please verify your email. "));
                }
                else
                {
                    return BadRequest(ResponseMessage.error("Email has already existed "));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }

        [HttpPost("verify")]
        public IActionResult Verify(string otp)
        {
            if (otp == verifi_OTP)
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
                systemuser = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == Common.Hash(user.Password) && x.IsActive == true);

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

        [HttpPut("resestpassword")]
        public IActionResult ResetPassword(string email)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.IsActive == true);
            if (user != null)
            {
                string resetpassword = CreateRandomString(10);
                user.Password = Common.Hash(resetpassword);
                _context.SaveChanges();
                string body = "Your Password is: " + resetpassword;
                sendEmail("Reset Password", body, email);
                return Ok(ResponseMessage.ok("We've sent new password to your email, please check your email"));
            }
            return BadRequest(ResponseMessage.error("Your email hasn't been used"));
        }

        [HttpPut("changepassword")]
        [Authorize(Roles = "User")]
        public IActionResult ChangePassword(ChangePasswordModel changepass)
        {
            var thisuser = _context.Users.SingleOrDefault(x => x.Id == systemuser.Id && x.IsActive == true);
            if (Common.Hash(changepass.CurrentPassword) == thisuser.Password)
            {
                thisuser.Password = Common.Hash(changepass.NewPassword);
                _context.SaveChanges();
                systemuser = thisuser;
                return Ok(ResponseMessage.ok("Change password sucessfully", thisuser.Password));
            }
            return BadRequest(ResponseMessage.error("Your current password is incorrect"));
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
        private void sendEmail(string subject, string body, string to)
        {
            string fromMail = "zealeducationa@gmail.com";
            string fromPassword = "pzmclcfqeqfwowhy";

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
        private string CreateRandomString(int length)
        {
            Random RNG = new Random();
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(RNG.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }

        
    }
}
