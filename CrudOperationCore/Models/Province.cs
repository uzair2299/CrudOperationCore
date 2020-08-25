using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }

        [StringLength(30)]
        public string ProvinceName { get; set; }
        public ICollection<City> cities { get; set; }
    }
}
