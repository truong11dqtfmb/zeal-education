using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using System.Collections.Generic;
using System.Linq;
using Zeal_education.Data;
using Zeal_education.Models;
using Zeal_education.Services;
using Zeal_education.Utils;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private zeal_educationContext _context;
        private IUserService _userService;


        public OrderController(zeal_educationContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("buy-now")]
        public IActionResult BuyNow(OrderRequest request)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                if (user != null)
                {
                    Order order = new Order
                    {
                        UserId = user.Id,
                        Note = request.note,
                        Status = false,
                        OrderDate = DateTime.Now,
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    Order lastOrder = _context.Orders.LastOrDefault();

                    int id = lastOrder.Id;

                    foreach (int item in request.courseIds)
                    {
                        Orderdetail orderdetail = new Orderdetail
                        {
                            CourseId = item,
                            OrderId = id,
                        };
                        _context.Orderdetails.Add(orderdetail);
                        _context.SaveChanges();
                    }
                    return Ok(ResponseMessage.ok("Buy now successfully"));
                }
                return BadRequest(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }


        [HttpGet("my-course")]
        public IActionResult MyCourse()
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                if (user != null)
                {
                    List<Order> orders = _context.Orders.Where(x => x.UserId == user.Id && x.Status == true).ToList();

                    return Ok(ResponseMessage.ok("Your Order", orders));
                }
                return BadRequest(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }

        [HttpGet("enable-order/{orderId}")]
        public IActionResult Enable(int orderId)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                if (user != null)
                {
                    Order order = _context.Orders.SingleOrDefault(x => x.UserId == user.Id && x.Id == orderId);

                    order.Status = true;

                    _context.SaveChanges();

                    return Ok(ResponseMessage.ok("Enable order successfully"));
                }
                return BadRequest(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }
    }
}