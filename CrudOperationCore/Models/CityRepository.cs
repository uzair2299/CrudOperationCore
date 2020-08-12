using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class CityRepository : ICityRepository
    {
        public CityRepository(ApplicationContext applicationContext)
        {
            _ApplicationContext = applicationContext;
        }

        public ApplicationContext _ApplicationContext { get; }

        public List<SelectListItem> GetCities(string Id)
        {
            if (Id != null)
            {
                int ID = Convert.ToInt32(Id);
                List<SelectListItem> Items = _ApplicationContext.Cities.OrderBy(x => x.CityName).Where(x => x.ProvinceId == ID).Select(x => new SelectListItem
                {
                    Value = x.CityId.ToString(),
                    Text = x.CityName
                }).ToList();
                var CityTip = new SelectListItem()
                {
                    Value = null,
                    Text = "---------- Select City ------------"
                };
                Items.Insert(0, CityTip);
                //return new SelectList(Items, "value", "Text");
                return Items;
            }
            return null;
        }



        public List<SelectListItem> GetProvinces()
        {
            
                List<SelectListItem> Items = _ApplicationContext.Provinces.OrderBy(x => x.ProvinceName).Select(x => new SelectListItem
                {
                    Value = x.ProvinceId.ToString(),
                    Text = x.ProvinceName
                }).ToList();
                var CityTip = new SelectListItem()
                {
                    Value = "",
                    Text = "---------- Select Province -----------"
                };
                Items.Insert(0, CityTip);
            return Items;
                //return new SelectList(Items, "value", "Text");
        }


        public List<SelectListItem> GetCitiesEmpty()
        {
            List<SelectListItem> Item = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "----------- Select City ------------"
                }
            };

            return Item;
        }
    }
}
