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
       // public int PageSize = 4;

        public EShopProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(string category/*int page = 1*/)
        {
            //ViewBag.SelectedCategory = category;
                
            
            
            return View(productRepository.Products.Where(p=>category==null||p.Category==category).OrderBy(x=>x.EShopProductId));
            //return View(productRepository.Products.OrderBy(x=>x.EShopProductId).Skip((page-1)*PageSize).Take(PageSize));
        }
    }
}
