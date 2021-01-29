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
    public class OrderService : IOrderService
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
                    DateOfOrder = DateTime.Now
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

        public bool DeleteOrder(Guid id)
        {
            try
            {
                var orderDb = db.Orders.Find(id);
                if (orderDb == null)
                {
                    throw new Exception("Заказ не найден");
                }
                else 
                {
                    db.Orders.Remove(orderDb);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления заказа.");
            }
        }

        public OrderVM GetOrderById(Guid id)
        {
            var orderDb = db.Orders.Find(id);
            if (orderDb == null)
            {
                throw new Exception("Заказ не найден");
            }
            else
            { 
                return new OrderVM { BuyerId = orderDb.BuyerId, DateOfOrder = orderDb.DateOfOrder };
            }
        }

        public List<OrderListItemVM> GetOrdersListByUserId(Guid id)
        {
            var orderList = db.Orders.Where(m => m.BuyerId.Equals(CurrentUser.Id)).ToList();
            if (orderList.Any())
            {
                var resultList = new List<OrderListItemVM>();
                foreach (var orderDb in orderList)
                {
                    resultList.Add(new OrderListItemVM {  CreationDate = orderDb.DateOfOrder, Id= orderDb.Id,  ProductsList = new List<Product>()});
                }
                return resultList;
            }
            else
            {
                return new List<OrderListItemVM>();
            }
        }


    }
}
