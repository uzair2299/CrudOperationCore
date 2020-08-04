using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set;}

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
    }
}
