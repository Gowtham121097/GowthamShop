using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCaterogyRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCaterogy> productCategories;

        public ProductCaterogyRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCaterogy>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCaterogy>();
            }
        }

        public void commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCaterogy product)
        {
            productCategories.Add(product);
        }

        public void Update(ProductCaterogy productCat)
        {
            ProductCaterogy productCatToUpdate = productCategories.Find(i => i.Id == productCat.Id);

            if (productCatToUpdate != null)
            {
                productCatToUpdate = productCat;
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }

        public ProductCaterogy Find(string Id)
        {
            ProductCaterogy productCat = productCategories.Find(i => i.Id == Id);
            if (productCat != null)
            {
                return productCat;
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }

        public IQueryable<ProductCaterogy> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCaterogy productToDelete = productCategories.Find(i => i.Id == Id);

            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }
    }
}
