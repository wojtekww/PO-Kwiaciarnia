using Xunit;
using System.Linq;
using Kwiaciarnia.Models;
using Kwiaciarnia.ViewModels;
using Kwiaciarnia.Controllers;
using Kwiaciarnia.tests.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kwiaciarnia.tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void ProductManagement_ReturnsAViewResult_ContainsAllProducts()
        {
            //arrange
            var mockProductRepository = RepositoryMocks.GetProductRepository();
            var mockOrderRepository = RepositoryMocks.GetOrderRepository();
            var mockOrderDetailRepository = RepositoryMocks.GetOrderDetailRepository();

            var employeeController = new EmployeeController(mockProductRepository.Object, mockOrderRepository.Object, mockOrderDetailRepository.Object);

            //act
            var result = employeeController.ProductManagement();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
            Assert.Equal(4, products.Count());
        }

        [Fact]
        public void AddProduct_Redirects_ValidProductViewModel()
        {
            //arrange

            var addEditProductViewModel = new AddEditProductViewModel();
            var mockProductRepository = RepositoryMocks.GetProductRepository();
            var mockOrderRepository = RepositoryMocks.GetOrderRepository();
            var mockOrderDetailRepository = RepositoryMocks.GetOrderDetailRepository();

            var product = mockProductRepository.Object.GetProductById(1);
            addEditProductViewModel.Id = product.Id;
            addEditProductViewModel.Name = product.Name;
            addEditProductViewModel.Category = product.Category;
            addEditProductViewModel.Price = product.Price;
            addEditProductViewModel.ImageUrl = product.ImageUrl;
            addEditProductViewModel.Description = product.Description;

            var employeeController = new EmployeeController(mockProductRepository.Object, mockOrderRepository.Object, mockOrderDetailRepository.Object);

            //act
            var result = employeeController.AddProduct(addEditProductViewModel);

            //assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ProductManagement", redirectToActionResult.ActionName);
        }
    }
}
