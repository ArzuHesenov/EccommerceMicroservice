using CorePackage.DataAccess.EntityFramework;
using CorePackage.Helpers.Result.Abstract;
using CorePackage.Helpers.Result.Concrete.SuccessResults;
using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess.Abstract;
using OrderService.Entities.Concrete;
using OrderService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Concrete
{
    public class OrderDal : EfRepositoryBase<Order, OrderDbContext>, IOrderDal
    {
        public IDataResult<OrderListDTO> GetOrderByUserId(string userId)
        {
            using(OrderDbContext _context = new())
            {
                var findOrder= _context.Orders.Include(x=>x.OrderItems).FirstOrDefault(x=>x.UserId == userId);
                List<OrderItemDTO> orderItems= new ();
                foreach (var item in findOrder.OrderItems)
                {
                    OrderItemDTO orderItemDTO = new()
                    {
                        ProductName = item.ProductName,
                        Price = item.Price,
                        PhotoUrl = item.PhotoUrl,
                        Quantity = item.Quantity,
                    };
                    orderItems.Add(orderItemDTO);
                }
                OrderListDTO order = new()
                {
                    Id = findOrder.Id,
                    UserId = findOrder.UserId,
                    OrderItems = orderItems,
                };
                return new SuccessDataResult<OrderListDTO>(order);
            }
        }
    }
}
