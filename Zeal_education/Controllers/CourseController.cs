using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zeal_education.Data;
using Zeal_education.Models;
using Zeal_education.Services;
using Zeal_education.Utils;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class CourseController : ControllerBase
    {
        private zeal_educationContext _context;
        private IUserService _userService;



        public CourseController(zeal_educationContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }
        [HttpPost("add")]
        public IActionResult Add(CourseModel course)
        {
            try
            {
                var newcourse = new Course
                {
                    CourseName = course.CourseName,
                    Description = course.Description,
                    CategoryId = course.CategoryId,
                    TeacherId = course.TeacherId,
                    Fee = course.Fee,
                    Title = course.Title,
                    CreateBy = _userService.GetUserName()
                };
                _context.Courses.Add(newcourse);
                _context.SaveChanges();
                return Ok(ResponseMessage.ok("add successfully", newcourse));

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
                var course = _context.Courses.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (course != null)
                {
                    course.IsActive = false;
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Delete successfully"));
                }
                return NotFound(ResponseMessage.error("Course not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var list = _context.Courses.Where(x => x.IsActive == true).ToList();
            return Ok(ResponseMessage.ok("Get data succesfully", list));
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetId(int id)
        {
            var course = _context.Courses.SingleOrDefault(x => x.Id == id && x.IsActive == true);
            if (course != null)
            {
                return Ok(ResponseMessage.ok("Get data successfully", course));
            }
            return NotFound(ResponseMessage.error("Teacher not found"));
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CourseModel course)
        {
            try
            {
                var thiscourse = _context.Courses.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (thiscourse != null)
                {
                    thiscourse.CourseName = course.CourseName;
                    thiscourse.Fee = course.Fee;
                    thiscourse.Title = course.Title;
                    thiscourse.TeacherId = course.TeacherId;
                    thiscourse.CategoryId = course.CategoryId;
                    thiscourse.Description = course.Description;
                    thiscourse.ModifyAt = DateTime.Now;
                    thiscourse.ModifyBy = _userService.GetUserName();
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Update successfully", thiscourse));
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
