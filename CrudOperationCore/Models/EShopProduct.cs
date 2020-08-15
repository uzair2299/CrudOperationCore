﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class EShopProduct
    {
        public int EShopProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
