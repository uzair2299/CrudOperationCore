using CrudOperationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore
{
   public  interface ICityRepository
    {
        List<SelectListItem> GetCities(string Id);
        List<SelectListItem> GetCitiesEmpty();
        List<SelectListItem> GetProvinces();
        List<Province> GetProvincesForjQuery();

    }
}
