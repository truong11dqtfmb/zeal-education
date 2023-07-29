using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Zeal_education.Data;
using Zeal_education.Models;
using System.Security.Cryptography;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        private zeal_educationContext _context;
    


        public UserController(zeal_educationContext context)
        {
            _context = context;
        }
        [HttpPost("add")]
        public IActionResult Add(UserModel user)
        {
            try
            {
                var newuser = new User
                {
                    Email= user.Email,
                    Password= Common.Hash(user.Password),
                    Dob = user.Dob,
                    FullName= user.FullName,
                    RoleId= user.RoleId,
                };
                _context.Users.Add(newuser);
                _context.SaveChanges();
                return Ok(ResponseMessage.ok("add successfully", newuser));

            }
            catch(Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (user != null)
                {
                    user.IsActive = false;
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Delete successfully"));
                }
                return NotFound(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var list = _context.Users.Where(x => x.IsActive == true).ToList();
            return Ok(ResponseMessage.ok("Get data succesfully", list));
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetId(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id && x.IsActive == true);
            if (user != null)
            {
                return Ok(ResponseMessage.ok("Get data successfully", user));
            }
            return NotFound(ResponseMessage.error("User not found"));
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UserModel user)
        {
            try
            {
                var thisuser = _context.Users.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (thisuser != null)
                {
                    thisuser.Email = user.Email;
                    thisuser.Password = Common.Hash(user.Password);
                    thisuser.Dob = user.Dob;
                    thisuser.FullName = user.FullName;
                    thisuser.RoleId = user.RoleId;
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Update successfully", thisuser));
                }
                return NotFound(ResponseMessage.error("User not found"));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
    }
}
