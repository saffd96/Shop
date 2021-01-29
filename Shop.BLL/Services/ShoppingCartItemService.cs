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
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private ShopDbModelContainer db;

        public ShoppingCartItemService()
        {
            db = new ShopDbModelContainer();
        }

        public bool CreateNewShoppingCartItem(Guid productId, int count)
        {
            try
            {
                ShoppingCartItem shoppingCartItemDb = new ShoppingCartItem
                {
                    ShoppingCartId = CurrentShoppingCartItem.ShoppingCartId,
                    Count = CurrentShoppingCartItem.Count,
                    ProductId = CurrentShoppingCartItem.ProductId
                };

                db.ShoppingCartItems.Add(shoppingCartItemDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShoppingCartItem(Guid id)
        {
            try
            {
                var shoppingCartItemDb = db.ShoppingCartItems.Find(id);
                if (shoppingCartItemDb == null)
                {
                    throw new Exception("Продукт в корзине не найден");
                }
                else
                {
                    db.ShoppingCartItems.Remove(shoppingCartItemDb);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления продукта из корзины.");
            }
        }

        public ShoppingCartItemVM GetShoppingCartItemById(Guid id)
        {
            var shoppingCartItemDb = db.ShoppingCartItems.Find(id);
            if (shoppingCartItemDb == null)
            {
                throw new Exception("Продукт не найден");
            }
            else
            {
                return new ShoppingCartItemVM { Count = shoppingCartItemDb.Count, ProductId = shoppingCartItemDb.ProductId};
            }
        }

        public List<ShoppingCartItemVM> GetShoppingCartItemListByOrderId()
        {
            var shoppingCartItemsList = db.ShoppingCartItems.Where(m => m.Id.Equals(CurrentOrder.Id)).ToList();
            if (shoppingCartItemsList.Any())
            {
                var resultList = new List<ShoppingCartItemVM>();
                foreach (var shoppingCartItemDb in shoppingCartItemsList)
                {
                    resultList.Add(new ShoppingCartItemVM { Count = shoppingCartItemDb.Count, ProductId = shoppingCartItemDb.ProductId });
                }
                return resultList;
            }
            else
            {
                return new List<ShoppingCartItemVM>();
            }
        }

        public ShoppingCartItemVM UpdateShoppingCartItem(Guid id, Guid productId, int count)
        {
            var shoppingCartItemDb = db.ShoppingCartItems.Find(id);
            if (shoppingCartItemDb == null)
            {
                throw new Exception("Продукт не найден");
            }
            else
            {
                shoppingCartItemDb.Count = count;
                shoppingCartItemDb.ProductId = productId;
                db.Entry(shoppingCartItemDb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new ShoppingCartItemVM { Count = shoppingCartItemDb.Count, ProductId = shoppingCartItemDb.ProductId };
        }
    }
}
