using CrudOperationCore.Interfaces;
using CrudOperationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationContext applicationContext;

        public EFProductRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public IEnumerable<EShopProduct> Products => applicationContext.EShopProducts;
    }
}
