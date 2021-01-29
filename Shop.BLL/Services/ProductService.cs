using Shop.BLL.Infrastructure;
using Shop.BLL.Interfaces;
using Shop.BLL.VMs;
using Shop.DAL;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ProductService : IProductService
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
                    Description = product.Description,
                    Amount = product.Amount,
                    Price = product.Price,
                    Id = product.Id
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
            try
            {
                var productDb = db.Products.Find(id);
                if (productDb == null)
                {
                    throw new Exception("Продукт не найден");
                }
                else
                {
                    db.Products.Remove(productDb);
                    db.SaveChanges();
                    Console.WriteLine("Продукт удален");
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления продукта.");
            }
        }

        public ProductVM GetProductById(Guid id)
        {
            var productDb = db.Products.Find(id);
            if (productDb == null)
            {
                throw new Exception("Продукт не найден");
            }
            else
            {
                return new ProductVM { Amount = productDb.Amount, Description = productDb.Description, Name = productDb.Name, Price = productDb.Price };
            }
        }

        public ProductVM UpdateProduct(ProductVM product)
        {
            var productDb = db.Products.Find(product);
            if (productDb == null)
            {
                throw new Exception("Продукт не найден");
            }
            else
            {
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Amount = product.Amount;
                productDb.Price = product.Price;

                db.Entry(productDb).State = EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine("Продукт изменен");

            }
            return new ProductVM { Amount = productDb.Amount, Description = productDb.Description, Name = productDb.Name, Price = productDb.Price };
        }
        public List<OrderListItemVM> GetOrdersListByUserId()
        {
            var orderList = db.Orders.Where(m => m.BuyerId.Equals(CurrentUser.Id)).ToList();
            if (orderList.Any())
            {
                var resultList = new List<OrderListItemVM>();
                foreach (var orderDb in orderList)
                {
                    resultList.Add(new OrderListItemVM { CreationDate = orderDb.DateOfOrder, Id = orderDb.Id });
                }
                return resultList;
            }
            else
            {
                return new List<OrderListItemVM>();
            }
            throw new NotImplementedException();
        }

        public List<ProductListItemVM> GetProductListFromShop()
        {
            var productList = db.Products.ToList();
            if (productList.Any())
            {
                var resultList = new List<ProductListItemVM>();
                foreach (var productDb in productList)
                {
                    resultList.Add(new ProductListItemVM { Amount = productDb.Amount, Description = productDb.Description, Name = productDb.Name, Price = productDb.Price, Id = productDb.Id});
                }
                return resultList;
            }
            else
            {
                return new List<ProductListItemVM>();
            }
        }
    }
}
