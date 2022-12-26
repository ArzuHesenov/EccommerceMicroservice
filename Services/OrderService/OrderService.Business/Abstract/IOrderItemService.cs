using CorePackage.Helpers.Result.Abstract;
using OrderService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Business.Abstract
{
    public interface IOrderItemService
    {
        IDataResult<List<OrderItemDTO>> Add(List<OrderItemDTO> orderItemDTO, string userId);
        IDataResult<List<OrderItemDTO>> GetByUserId(string userId);
        IResult RemoveOrderItem(int itemId);
    }
}
