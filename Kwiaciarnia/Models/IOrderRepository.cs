using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void CreateOrder(Order order);
        Order GetOrderById(int orderId);
        void ChangeOrderStatus(Order order);
    }
}
