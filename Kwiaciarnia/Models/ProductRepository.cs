using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return _appDbContext.Products;
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == productId);
        }
        public void AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product old = GetProductById(product.Id);
            old.Name = product.Name;
            old.Category = product.Category;
            old.Price = product.Price;
            old.ImageUrl = product.ImageUrl;
            old.Description = product.Description;
            _appDbContext.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {            
            _appDbContext.Remove(product); //exception jak produkt jest w jakims zamowieniu            
            _appDbContext.SaveChanges();
        }
    }
}
