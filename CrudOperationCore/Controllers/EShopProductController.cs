using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationCore.Controllers
{
    public class EShopProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public EShopProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View(productRepository.Products);
        }
    }
}
