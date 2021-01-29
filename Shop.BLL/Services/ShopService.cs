using Shop.BLL.Interfaces;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ShopService : IShopService
    {
        private ShopDbModelContainer db;
        public ShopService()
        {
            db = new ShopDbModelContainer();
        }
        public void UpdateShop(string name, string description)
        {
            // Shop shop = 
        }
    }
}
