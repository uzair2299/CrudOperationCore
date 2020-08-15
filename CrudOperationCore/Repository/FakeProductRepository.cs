using CrudOperationCore.Interfaces;
using CrudOperationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Repository
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<EShopProduct> Products => new List<EShopProduct>
        {
            new EShopProduct { Name = "Football", Price = 25 },
            new EShopProduct { Name = "Surf board", Price = 179 },
            new EShopProduct { Name = "Running shoes", Price = 95 }
        };
    }
}
