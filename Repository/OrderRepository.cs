using Entities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        MyStorContext _dbcontext;

        public OrderRepository(MyStorContext myStorContext)
        {
            _dbcontext = myStorContext;
        }

        public Order AddOrder(Order order)
        {
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
            return order;
        }
    }
}
