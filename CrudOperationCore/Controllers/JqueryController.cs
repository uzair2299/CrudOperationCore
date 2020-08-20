using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationCore.Controllers
{
    public class JqueryController : Controller
    {
        private readonly ICityRepository cityRepository;

        public JqueryController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProvince()
        {

            return Json(cityRepository.GetProvincesForjQuery());
        }
    }


    
        

    
}
