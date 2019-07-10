using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products;

        public IEnumerable<Product> Products => throw new NotImplementedException();

        public MockProductRepository()
        {
            if(_products == null)
            {
                InitializeProducts();
            }
        }

        private void InitializeProducts()
        {
            _products = new List<Product>
            {
                new Product {Id = 1, Name = "Róża", Category = "Kwiaty cięte", Price = 5.99M , Description = "Opis róży", ImageUrl = "images/roza.jpg", IsOnPromotion = false},
                new Product { Id = 3, Name = "Doniczka mała", Category = "Akcesoria", Price = 7.99M, Description = "Opis doniczki", ImageUrl = "images/doniczka.jpg", IsOnPromotion = false },
                new Product { Id = 2, Name = "Tulipan", Category = "Kwiaty cięte", Price = 3.99M, Description = "Opis tulipana", ImageUrl = "images/tulipan.jpg", IsOnPromotion = false },
                new Product { Id = 4, Name = "Bukiet wiosenny", Category = "Bukiety", Price = 3.99M, Description = "Opis bukietu", ImageUrl = "images/bukiet_wiosenny.jpg", IsOnPromotion = false }
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
