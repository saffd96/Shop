using Shop.BLL.Interfaces;
using Shop.BLL.VMs;
using Shop.DAL;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    class ProductService : IProductService
    {
        private ShopDbModelContainer db;
        public ProductService()
        {
            db = new ShopDbModelContainer();
        }
        public bool CreateNewProduct(ProductVM product)
        {
            try
            {
                Product productDb = new Product
                {
                    Name = product.Name,
                    Description=product.Description,
                    Amount=product.Amount,
                    Price=product.Price
                };

                db.Products.Add(productDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductVM GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductVM UpdateProduct(ProductVM product)
        {
            throw new NotImplementedException();
        }
    }
}
