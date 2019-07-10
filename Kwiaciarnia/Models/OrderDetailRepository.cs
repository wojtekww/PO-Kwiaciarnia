using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderDetailRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            List<OrderDetail> DetailsList = new List<OrderDetail>(); ;
            foreach(OrderDetail od in _appDbContext.OrderDetails)
            {
                if (od.OrderId == id)
                    DetailsList.Add(od);
            }
            return DetailsList;
        }
    }
}
