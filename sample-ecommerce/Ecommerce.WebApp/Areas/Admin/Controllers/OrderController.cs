﻿using Ecommerce.Data.DataContext;
using Ecommerce.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Ecommerce.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/order")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly DataDbContext _context;

        public OrderController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index/{status}")]
        [Route("{status}")]
        public async Task<IActionResult> Index(int status)
        {
            var item = (from order in _context.Orders
                        orderby order.Id descending
                        select new ListOrdersViewModel()
                        {
                            OrderId = order.Id,
                            OrderDate = order.OrderDate,
                            OrderStatus = order.Status,
                            ShipAddress = order.ShipAddress,
                            ShipEmail = order.ShipEmail,
                            ShipName = order.ShipName,
                            ShipPhoneNumber = order.ShipPhoneNumber,
                            UserId = order.UserId,
                            Detail = (from d in _context.OrderDetails
                                      where order.Id == d.OrderId
                                      select new OrderDetailViewModel()
                                      {
                                          OrderId = d.OrderId,
                                          Price = d.Price,
                                          ProductId = d.ProductId,
                                          Quantity = d.Quantity,
                                          Id = d.Id,
                                          Product = (from pr in _context.Products
                                                     where d.ProductId == pr.Id
                                                     select pr).FirstOrDefault(),
                                      }).AsEnumerable()
                        });
            var items = await item.ToListAsync();
            switch (status)
            {
                case 0:
                    items = await item.Where(p => p.OrderStatus == 0).ToListAsync();
                    break;
                case 1:
                    items = await item.Where(p => p.OrderStatus == 1).ToListAsync();
                    break;
                case 2:
                    items = await item.Where(p => p.OrderStatus == 2).ToListAsync();
                    break;
                case 3:
                    items = await item.Where(p => p.OrderStatus == 3).ToListAsync();
                    break;
                case 4:
                    items = await item.Where(p => p.OrderStatus == 4).ToListAsync();
                    break;
                case 5:
                    items = await item.ToListAsync();
                    break;
                default:
                    items = await item.ToListAsync();
                    break;
            }

            return View(items);
        }

        [Route("update-order-status/{orderId}/{status}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, int status)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(ord => ord.Id == orderId);
            order.Status = status;

            #region Trường hợp hủy đơn => Hoàn lại số lượng
            if (status == 0)
            {
                var order_soluong = _context.OrderDetails.Where(n => n.OrderId == orderId).ToList();
                foreach(var item in order_soluong)
                {
                    var product_soluong = _context.Products.SingleOrDefault(n => n.Id == item.ProductId);
                    product_soluong.Quantity = product_soluong.Quantity + item.Quantity;
                    _context.Products.Update(product_soluong);
                    await _context.SaveChangesAsync();
                }
            }
            #endregion

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
