using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zeal_education.Data;
using Zeal_education.Models;
using Zeal_education.Services;
using Zeal_education.Utils;

namespace Zeal_education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CartController : ControllerBase
    {
        private zeal_educationContext _context;
        private IUserService _userService;


        public CartController(zeal_educationContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("get-all-cart")]
        public IActionResult GetAllCart()
        {
            try
            {
                //var user = _userService.GetUser();

                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                if (user != null)
                {
                    var cart = _context.Carts.SingleOrDefault(x => x.UserId == user.Id && x.IsActive == true);

                    if(cart == null)
                    {
                        Cart c = new Cart
                        {
                            UserId = user.Id
                        };
                        cart = c;
                        _context.Carts.Add(c);
                        _context.SaveChanges();
                    }

                    int cartId = cart.Id;

                    var listCartItem = _context.Cartitems.Where(x => x.CartId == cartId && x.IsActive == true).ToList();

                    return Ok(ResponseMessage.ok("Get cart by User: " + user.FullName, listCartItem));
                }
                return BadRequest(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }


        [HttpPost("add-to-cart/{courseId}")]
        public IActionResult AddToCart(int courseId)
        {
            try
            {

                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                //User user = _userService.GetUser();

                if (user != null)
                {
                    var cart = _context.Carts.SingleOrDefault(x => x.UserId == user.Id && x.IsActive == true);

                    if (cart == null)
                    {
                        Cart c = new Cart
                        {
                            UserId = user.Id
                        };
                        cart = c;
                        _context.Carts.Add(c);
                        _context.SaveChanges();
                    }

                    int cartId = cart.Id;


                    Cartitem item = _context.Cartitems.SingleOrDefault(x => x.CourseId== courseId && x.CartId == cartId && x.IsActive == true);
                    if(item != null)
                    {
                        return Ok(ResponseMessage.ok("Course exists your Cart", item));
                    }

                    Cartitem cartitem = new Cartitem
                    {
                        CourseId = courseId,
                        CartId = cartId,
                    };

                    _context.Cartitems.Add(cartitem);
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Add to cart successfully", cartitem));
                }
                return BadRequest(ResponseMessage.error("User not found"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessage.error(ex.Message));
            }
        }

        [HttpPost("delete-to-cart/{courseId}")]
        public IActionResult DeleteToCart(int courseId)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == _userService.GetUserName() && x.IsActive == true);

                if (user != null)
                {
                    var cart = _context.Carts.SingleOrDefault(x => x.UserId == user.Id && x.IsActive == true);

                    int cartId = cart.Id;

                    var cartitem = _context.Cartitems.SingleOrDefault(x => x.CourseId == courseId && x.IsActive == true);

                    _context.Cartitems.Remove(cartitem);
                    _context.SaveChanges();
                    return Ok(ResponseMessage.ok("Delete to cart successfully", cartitem));
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