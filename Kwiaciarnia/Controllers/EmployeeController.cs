using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kwiaciarnia.Models;
using Kwiaciarnia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kwiaciarnia.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public EmployeeController(IProductRepository productRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public IActionResult ProductManagement()
        {
            var products = _productRepository.Products;
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult Index()
        {
            int newOrders = 0;
            foreach (Order o in _orderRepository.Orders)
                if (o.Status == "Nowe")
                {
                    newOrders++;
                }                
            return View(newOrders);
        }
        public IActionResult OrderManagement()
        {           
            var orders = _orderRepository.Orders.OrderByDescending(o => o.OrderPlaced); 
            return View(orders);
        }
        public IActionResult OrderDetails(int id)
        {
            var products = _productRepository.GetAllProducts().OrderBy(p => p.Name);

            var orderDetailsViewModel = new OrderDetailsViewModel()
            {
                Order = _orderRepository.GetOrderById(id),
                OrderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(id),
                Status= _orderRepository.GetOrderById(id).Status
            };
            return View(orderDetailsViewModel);
        }
        [HttpPost]
        public IActionResult OrderDetails(OrderDetailsViewModel orderDetailsViewModel, int id)
        {
            Order order = new Order
            {
                OrderId = id,
                Status = orderDetailsViewModel.Status
            };
            
            _orderRepository.ChangeOrderStatus(order);
            //order = _orderRepository.GetOrderById(id);
            //List<OrderDetail> list = _orderDetailRepository.GetOrderDetailsByOrderId(id);
            //var vm = new OrderDetailsViewModel() { Order = order, OrderDetails = list, Status = order.Status};

            //return View(vm);
            return RedirectToAction("OrderManagement");
        }

        [HttpPost]
        public IActionResult AddProduct(AddEditProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid) return View(addProductViewModel);

            var product = new Product()
            {
                Name = addProductViewModel.Name,
                Category = addProductViewModel.Category,
                Price = addProductViewModel.Price,
                ImageUrl = addProductViewModel.ImageUrl,
                Description = addProductViewModel.Description
            };
            _productRepository.AddProduct(product);
            return RedirectToAction("ProductManagement");
        }

        public IActionResult EditProduct(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
                return RedirectToAction("ProductManagement", _productRepository.Products);

            var vm = new AddEditProductViewModel() { Id = product.Id, Name = product.Name, Category = product.Category, Price = product.Price, ImageUrl = product.ImageUrl, Description = product.Description };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditProduct(AddEditProductViewModel addProductViewModel)
        {
            var product = _productRepository.GetProductById(addProductViewModel.Id);

            if (product != null)
            {
                product.Name = addProductViewModel.Name;
                product.Category = addProductViewModel.Category;
                product.Price = addProductViewModel.Price;
                product.ImageUrl = addProductViewModel.ImageUrl;
                product.Description = addProductViewModel.Description;

                if (!ModelState.IsValid) return View(addProductViewModel);

                _productRepository.UpdateProduct(product);
                return RedirectToAction("ProductManagement", _productRepository.Products);
            }

            return RedirectToAction("ProductManagement", _productRepository.Products);
        }

        
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product != null)
            {
                _productRepository.DeleteProduct(product);               
            }
            else
            {
                ModelState.AddModelError("", "Nie można znaleźć wybranego produktu.");
            }
            return View("ProductManagement", _productRepository.Products);
        }
    }
}
