using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(SimpleRepository.SharedRepository.Products.Where(x=>x.Price>50));
        }
    }
}
