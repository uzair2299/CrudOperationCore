using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationCore.ExtensionMethod;
using CrudOperationCore.Interfaces;
using CrudOperationCore.Models;
using CrudOperationCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationCore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;

        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(string returnUrl)
        {
            
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public IActionResult AddtoCart(int Id ,string returnUrl)
        {
            EShopProduct eShopProduct = productRepository.Products.FirstOrDefault(x => x.EShopProductId == Id);
            if (eShopProduct != null)
            {
                Cart cart = GetCart();
                cart.AddItem(eShopProduct, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            EShopProduct product = productRepository.Products.FirstOrDefault(p => p.EShopProductId == productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
