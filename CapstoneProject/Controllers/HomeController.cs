using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CapstoneProject.Models;
using CapstoneProject.Services;

namespace CapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly ProductService _productService;

        //public HomeController(ProductService productService)
        //{
        //    _productService = productService;
        //}

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Products()
        {
            return View(_productService.Get());
        }

        public ViewResult Create()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Product> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(product);
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Car car)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        carService.Create(car);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(car);
        //}
    }
}
