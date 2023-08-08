using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zeal_education.Data;
using Zeal_education.Models;
using Zeal_education.Services;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TeacherController : ControllerBase
    {
        private zeal_educationContext _context;
        private IUserService _userService;



        public TeacherController(zeal_educationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [HttpPost("add")]
        public IActionResult Add(TeacherModel teacher)
        {
            try
            {
                var newteacher = new Teacher
                {
                    FullName = teacher.FullName,
                    Description = teacher.Description,
                    Dob = teacher.Dob,
                    CreateBy = _userService.GetUserName()
                };
                _context.Teachers.Add(newteacher);
                _context.SaveChanges();
                return Ok(ResponseMessage.ok("add successfully", newteacher));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_context.Courses.Any(x => x.TeacherId == id))
                {
                    return BadRequest(ResponseMessage.error("You need to delete course first"));
                }
                var teacher = _context.Teachers.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (teacher != null)
                {
                    teacher.IsActive = false;
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Delete successfully"));
                }
                return NotFound(ResponseMessage.error("Teacher not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var list = _context.Teachers.Where(x => x.IsActive == true).ToList();
            return Ok(ResponseMessage.ok("Get data succesfully", list));
        }
        [HttpGet("getbyid/{id}")]
        [AllowAnonymous]
        public IActionResult GetId(int id)
        {
            var category = _context.Teachers.SingleOrDefault(x => x.Id == id && x.IsActive == true);
            if (category != null)
            {
                return Ok(ResponseMessage.ok("Get data successfully", category));
            }
            return NotFound(ResponseMessage.error("Teacher not found"));
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, TeacherModel teacher)
        {
            try
            {
                var thisteacher = _context.Teachers.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (thisteacher != null)
                {
                    thisteacher.FullName = teacher.FullName;
                    thisteacher.Dob = teacher.Dob;
                    thisteacher.Description = teacher.Description;
                    thisteacher.ModifyAt = DateTime.Now;
                    thisteacher.ModifyBy = _userService.GetUserName();
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Update successfully", thisteacher));
                }
                return NotFound(ResponseMessage.error("Teacher not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
    }
}
