using CrudOperationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Interfaces
{
   public interface IProductRepository
    {
        IEnumerable<EShopProduct> Products { get; }
    }
}
