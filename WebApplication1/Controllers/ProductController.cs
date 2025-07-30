using Microsoft.AspNetCore.Mvc;
using TiendaVirtualMVC.Models;
using System.Collections.Generic;

namespace TiendaVirtualMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Name = "Producto 1", Description = "Descripción 1", Price = 10 },
                new Product { Name = "Producto 2", Description = "Descripción 2", Price = 15 }
            };

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Aquí podrías guardar el producto en una lista o base de datos
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}

