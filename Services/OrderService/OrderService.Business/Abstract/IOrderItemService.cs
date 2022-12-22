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
        IDataResult<ICollection<OrderItemDTO>> Add(ICollection<OrderItemDTO> orderItemDTO, string userId);
        IDataResult<ICollection<OrderItemDTO>> GetByUserId(string userId);
        IResult RemoveOrderItem(int itemId);
    }
}
