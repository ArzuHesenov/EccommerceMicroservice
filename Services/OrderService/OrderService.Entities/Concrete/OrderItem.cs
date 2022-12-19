﻿using CorePackage.Entities;
using CorePackage.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Entities.Concrete
{
    public class OrderItem : IEntity
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateAd { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
    }
}