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
    public class CategoryController : ControllerBase
    {
        private zeal_educationContext _context;
        private IUserService _userService;


        public CategoryController(zeal_educationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [HttpPost("add")]
        public IActionResult Add(CategoryModel category)
        {
            try
            {
                var newcata = new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                    CreateBy = _userService.GetUserName()
                };
                _context.Categories.Add(newcata);
                _context.SaveChanges();
                return Ok(ResponseMessage.ok("add successfully", newcata));

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
                var category = _context.Categories.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (category != null)
                {
                    category.IsActive = false;
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Delete successfully"));
                }
                return NotFound(ResponseMessage.error("Category not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var list = _context.Categories.Where(x => x.IsActive == true).ToList();
            return Ok(ResponseMessage.ok("Get data succesfully", list));
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetId(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id && x.IsActive == true);
            if (category != null)
            {
                return Ok(ResponseMessage.ok("Get data successfully", category));
            }
            return NotFound(ResponseMessage.error("Catefory not found"));
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CategoryModel category)
        {
            try
            {
                var thiscategory = _context.Categories.SingleOrDefault(x => x.Id == id && x.IsActive == true);
                if (thiscategory != null)
                {
                    thiscategory.Name = category.Name;
                    thiscategory.Description = category.Description;
                    thiscategory.ModifyAt = DateTime.Now;
                    thiscategory.ModifyBy = _userService.GetUserName();
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Update successfully", thiscategory));
                }
                return NotFound(ResponseMessage.error("Category not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
    }
}
