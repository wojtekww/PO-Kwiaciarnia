using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetailsByOrderId(int id);
    }
}
