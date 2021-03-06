﻿using System;
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
        bool productisAdded;

        private readonly ProductService _productService;

        //public HomeController(ProductService productService)
        //{
        //    _productService = productService;
        //}

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            productisAdded = false;
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Products(string sortOrder, string searchString){
        
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var products = from p in _productService.Get()
                           select p;

            if(!String.IsNullOrEmpty(searchString)){
                products = products.Where(p => p.Name.Contains(searchString) ||
                p.Description.Contains(searchString));
            }

            switch(sortOrder){
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            return View(products.ToList());
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Details(string? id)
        {
            var product = _productService.Get(id);
            return View(product);
        }

/*        public ViewResult Products()
        {
            return View(_productService.Get());
        }*/

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
            productisAdded = false;
            if (ModelState.IsValid)
            {
                productisAdded = true;
                _productService.Create(product);
                ViewBag.Alert = productisAdded;

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
