using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItems = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };
            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
        }
        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);



        //This class stores model objects in memory, which means that any changes to the model are lost when the application is stopped or restarted

        /// <summary>
        /// When you define a static method or field, it does not have access to any instance fields defined for the class;it can use only fields that are marked as static.
        /// Furthermore, it can directly invoke only other methods in the class that are marked as static; nonstatic (instance) methods or fields must first create an object on which to call them
        /// </summary>
    }
}
