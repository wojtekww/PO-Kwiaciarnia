using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return _appDbContext.Orders;
            }
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.Status = "Nowe";
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();    
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.Id,
                    ProductName = shoppingCartItem.Product.Name,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Product.Price                 
                    
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }
            
            _appDbContext.SaveChanges();
        }
        public Order GetOrderById(int orderId)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
        public void ChangeOrderStatus(Order order)
        {
            Order old = GetOrderById(order.OrderId);
            old.Status = order.Status;
            _appDbContext.SaveChanges();
        }
    }
}
