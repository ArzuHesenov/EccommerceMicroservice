using CorePackage.Helpers.Result.Abstract;
using CorePackage.Helpers.Result.Concrete.ErrorResults;
using CorePackage.Helpers.Result.Concrete.SuccessResults;
using OrderService.Business.Abstract;
using OrderService.DataAccess.Abstract;
using OrderService.Entities.Concrete;
using OrderService.Entities.DTOs;

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
        public IDataResult<List<OrderItemDTO>> Add(List<OrderItemDTO> orderItemDTO, string userId)
        {
            try
            {
                var result = _orderService.GetOrderByUserId(userId);
                if (result.Data == null)
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
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        PhotoUrl = item.PhotoUrl,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        OrderId = result.Data.Id
                    };
                    _orderDal.Add(orderItem);
                }
                return new SuccessDataResult<List<OrderItemDTO>>(orderItemDTO);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<OrderItemDTO>>(e.Message);
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
        IDataResult<List<OrderItemDTO>> IOrderItemService.GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
