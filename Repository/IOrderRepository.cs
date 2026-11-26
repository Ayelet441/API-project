using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
    }
}