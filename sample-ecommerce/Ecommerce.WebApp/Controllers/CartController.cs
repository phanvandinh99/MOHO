﻿using Ecommerce.Data.DataContext;
using Ecommerce.Data.Entities;
using Ecommerce.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> userManager;

        public CartController(DataDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("add-to-cart")]
        [Authorize]
        public async Task<IActionResult> AddItemToCart(int productId, int quantity, decimal price)
        {
            var currentUserId = await userManager.GetUserAsync(User);

            // Tìm kiếm sản phẩm
            Product product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại." });
            }

            // Kiểm tra số lượng trong kho đủ đáp ứng không
            if (product.Quantity < quantity)
            {
                return BadRequest(new { message = "Sản phẩm không đáp ứng số lượng yêu cầu." });
            }

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var existingCart = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == currentUserId.Id);

            if (existingCart == null)
            {
                // Tạo mới sản phẩm trong giỏ hàng
                Cart item = new Cart
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    DateCreated = DateTime.Now,
                    UserId = currentUserId.Id,
                };
                _context.Carts.Add(item);
            }
            else
            {
                // Cập nhật số lượng sản phẩm trong giỏ hàng
                existingCart.Quantity += quantity;
                _context.Carts.Update(existingCart);
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Thêm vào giỏ hàng thành công." });
        }


        [HttpGet]
        [Route("check-item/{productId}")]
        [Authorize]
        public async Task<bool> CheckExistItem(int productId)
        {
            var currentUserId = await userManager.GetUserAsync(User);

            // check exist item and increase quantity
            var check = await _context.Carts.Where(c => c.ProductId == productId && c.UserId == currentUserId.Id).CountAsync();

            // = 0 thi KHONG ton tai
            if(check == 0)
            {
                return true;
            }
            return false;
        }


        [HttpGet]
        [Route("count-item")]
        [Authorize]
        public async Task<IActionResult> CountItemInCart()
        {
            var currentUserId = await userManager.GetUserAsync(User);
            var cart = await _context.Carts.Where(c => c.UserId == currentUserId.Id).CountAsync();

            return Ok(cart);
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUserId = await userManager.GetUserAsync(User);

            var cart = await (from c in _context.Carts
                        join pr in _context.Products on c.ProductId equals pr.Id
                        where c.UserId == currentUserId.Id
                        orderby c.DateCreated descending
                        select new ListCartViewModel()
                        {
                            ProductId = pr.Id,
                            ProductName = pr.Name,
                            ProductImage = pr.UrlImage,
                            CartId = decimal.ToInt32(c.Id),
                            CartPrice = c.Price,
                            CartQuantity = c.Quantity,
                            CartTotal = decimal.ToInt32((decimal)c.Price) * c.Quantity,
                            ProductSlug = pr.Slug
                        }).ToListAsync();

            return View(cart);
        }

        [HttpGet]
        [Route("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Carts.Where(p => p.Id == id).FirstOrDefaultAsync();
            _context.Carts.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("update-quantity/{id}/{type}")]
        [Authorize]
        public async Task<IActionResult> UpdateItemQuantity(int id, int type)
        {
            // type = 1 => increase
            // type = 0 => decrease
            if (type == 1)
            {

                var item = await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
                item.Quantity += 1;
                _context.Carts.Update(item);
                await _context.SaveChangesAsync();

                var cart = await (from c in _context.Carts
                                  join pr in _context.Products on c.ProductId equals pr.Id
                                  where c.Id == item.Id
                                  orderby c.DateCreated descending
                                  select new ListCartViewModel()
                                  {
                                      ProductId = pr.Id,
                                      ProductName = pr.Name,
                                      ProductImage = pr.UrlImage,
                                      CartId = decimal.ToInt32(c.Id),
                                      CartPrice = c.Price,
                                      CartQuantity = c.Quantity,
                                      CartTotal = decimal.ToInt32((decimal)c.Price) * c.Quantity,
                                      ProductSlug = pr.Slug
                                  }).FirstOrDefaultAsync();

                

                return Ok(cart);
            } else if(type == 0)
            {
                var item = await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
                item.Quantity -= 1;
                _context.Carts.Update(item);
                await _context.SaveChangesAsync();

                var cart = await (from c in _context.Carts
                                  join pr in _context.Products on c.ProductId equals pr.Id
                                  where c.Id == item.Id
                                  orderby c.DateCreated descending
                                  select new ListCartViewModel()
                                  {
                                      ProductId = pr.Id,
                                      ProductName = pr.Name,
                                      ProductImage = pr.UrlImage,
                                      CartId = decimal.ToInt32(c.Id),
                                      CartPrice = c.Price,
                                      CartQuantity = c.Quantity,
                                      CartTotal = decimal.ToInt32((decimal)c.Price) * c.Quantity,
                                      ProductSlug = pr.Slug
                                  }).FirstOrDefaultAsync();

                return Ok(cart);
            } else
            {
                return BadRequest();
            }
        }

    }
}
