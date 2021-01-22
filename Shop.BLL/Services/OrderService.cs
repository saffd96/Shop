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
    class OrderService : IOrderService
    {
        private ShopDbModelContainer db;
        public OrderService()
        {
            db = new ShopDbModelContainer();
        }

        public OrderVM CreateNewOrder(Guid buyerId)
        {
            try
            {
                Order orderDb = new Order
                {
                    BuyerId = CurrentUser.Id,
                    DateOfOrder = DateTime.Now,
                };

                db.Orders.Add(orderDb);
                db.SaveChanges();
                return new OrderVM {BuyerId=orderDb.BuyerId};
            }
            catch
            {
                throw new Exception("Ошибка создания заказа.");
            }
        }

        public bool DeleteOrder(Guid id)   //!!!!!!!!!
        {
            try
            {
                Order orderDb = new Order
                {
                    Id = CurrentOrder.Id,
                };

                db.Orders.Remove(orderDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка удаления заказа.");
            }
        }

        public OrderVM GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderVM UpdateOrder(Guid buyerId)
        {
            throw new NotImplementedException();
        }

    }
}
