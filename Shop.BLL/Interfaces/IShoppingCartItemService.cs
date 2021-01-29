using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IShoppingCartItemService
    {
        bool CreateNewShoppingCartItem(Guid productId, int count);
        ShoppingCartItemVM GetShoppingCartItemById(Guid id);
        List<ShoppingCartItemVM> GetShoppingCartItemListByOrderId();
        ShoppingCartItemVM UpdateShoppingCartItem(Guid id, Guid productId, int count);
        bool DeleteShoppingCartItem(Guid id);
    }
}
