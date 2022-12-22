using CorePackage.Helpers.Result.Abstract;
using CorePackage.Helpers.Result.Concrete.ErrorResults;
using CorePackage.Helpers.Result.Concrete.SuccessResults;
using OrderService.Business.Abstract;
using OrderService.DataAccess.Abstract;
using OrderService.Entities.Concrete;
using OrderService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderDal;
        private readonly IOrderService _orderService;

        public OrderItemManager(IOrderItemDal orderDal, IOrderService orderService)
        {
            _orderDal = orderDal;
            _orderService = orderService;
        }

        public IDataResult<ICollection<OrderItemDTO>> Add(ICollection<OrderItemDTO> orderItemDTO, string userId)
        {
            try
            {
                var result = _orderService.GetOrderByUserId(userId);
                if (result.Data==null)
                {
                    OrderAddDTO orderAddDTO = new()
                    {
                        UserId = userId,
                    };
                    _orderService.AddOrder(orderAddDTO);
                }
                foreach (var item in orderItemDTO)
                {
                    OrderItem orderItem = new()
                    {
                        ProductName = item.ProductName,
                        PhotoUrl = item.PhotoUrl,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        OrderId = result.Data.Id
                    };
                    _orderDal.Add(orderItem);
                }
                return new SuccessDataResult<ICollection<OrderItemDTO>>(orderItemDTO);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<OrderItemDTO>>(e.Message);
            }
        }

        public IDataResult<ICollection<OrderItemDTO>> GetByUserId(string userId)
        {
            try
            {
            var result = _orderDal.Get(x => x.UserId == userId);
                return new SuccessDataResult<ICollection<OrderItemDTO>>(result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<OrderItemDTO>>(e.Message);
            }
        }

        public IResult RemoveOrderItem(int itemId)
        {
            try
            {
                OrderItem orderItem = new()
                {
                    Id = itemId
                };
                var result = _orderDal.Get(x => x.OrderId == orderItem.OrderId);
                _orderDal.Delete(result);
                return new ErrorResult("Sifaris silindi");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
