using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository repository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public Order AddOrder(Order order)
        {
            return repository.AddOrder(order);
        }
    }
}
