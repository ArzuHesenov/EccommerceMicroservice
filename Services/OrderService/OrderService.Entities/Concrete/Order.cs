using CorePackage.Entities;
using CorePackage.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
