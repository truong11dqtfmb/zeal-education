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
    public class ReportController : ControllerBase
    {
        private IUserService _userservice;



        public ReportController(IUserService userService)
        {
            _userservice= userService;
        }

        [HttpGet("numberofcoursebycategory")]
        public IActionResult Get()
        {
            var list = UltilSql.GetNumberOfCourseByCategory();
            return Ok(ResponseMessage.ok("Get Data successfully", list));
        }
    }
}
