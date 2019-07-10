using System;
using System.Collections.Generic;
using System.Text;
using Kwiaciarnia.Models;
using Xunit;
namespace Kwiaciarnia.tests
{
    public class SimpleTests
    {
        [Fact]
        public void CanUpdateProductPrice()
        {
            // Arrange
            var product = new Product { Name = "Przykładowy produkt", Price = 12.95M };
            // Act
            product.Price = 20M;
            //Assert
            Assert.Equal(20M, product.Price);
        }

        [Fact]
        public void CanUpdateProductName()
        {
            // Arrange
            var product = new Product { Name = "Przykładowy produkt", Price = 12.95M };
            // Act
            product.Name = "Inny produkt";
            //Assert
            Assert.Equal("Inny produkt", product.Name);
        }
    }
}

