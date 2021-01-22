using Shop.BLL.Infrastructure;
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
    class ShoppingCartItemService : IShoppingCartItemService
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
                    ProductID = CurrentShoppingCartItem.ProductId
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
            throw new NotImplementedException();
        }

        public ShoppingCartItemVM GetShoppingCartItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartItemVM UpdateShoppingCartItem(Guid productId, Guid shoppingCartId, int count)
        {
            throw new NotImplementedException();
        }
    }
}
