using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kwiaciarnia.Models;
using Kwiaciarnia.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kwiaciarnia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Witaj w kwiaciarni!",
                Products = products.ToList()
            };

            return View(homeViewModel);
        }
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
