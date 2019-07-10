using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kwiaciarnia.Models;
using Moq;

namespace Kwiaciarnia.tests.Model
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Róża", Category = "Kwiaty cięte", Price = 5.99M , Description = "Opis róży", ImageUrl = "images/roza.jpg", IsOnPromotion = false, IsInStock = true},
                new Product {Id = 2,Name = "Doniczka mała", Category = "Akcesoria", Price = 7.99M, Description = "Opis doniczki", ImageUrl = "images/doniczka.jpg", IsOnPromotion = false, IsInStock = true },
                new Product {Id = 3,Name = "Tulipan", Category = "Kwiaty cięte", Price = 3.99M, Description = "Opis tulipana", ImageUrl = "images/tulipan.jpg", IsOnPromotion = false, IsInStock = true },
                new Product {Id = 4,Name = "Bukiet wiosenny", Category = "Bukiety", Price = 3.99M, Description = "Opis bukietu", ImageUrl = "images/bukiet_wiosenny.jpg", IsOnPromotion = false, IsInStock = true },
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.Products).Returns(products);
            mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);
            mockProductRepository.Setup(repo => repo.AddProduct(It.IsAny<Product>())).Callback<Product>((p) => products.Add(p));



            return mockProductRepository;
        }
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            return mockOrderRepository;
        }
        public static Mock<IOrderDetailRepository> GetOrderDetailRepository()
        {
            var mockOrderDetailRepository = new Mock<IOrderDetailRepository>();
            return mockOrderDetailRepository;
        }
    }
}