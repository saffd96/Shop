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
    public class OrderItemService : IOrderItemService
    {
        private ShopDbModelContainer db;
        public OrderItemService()
        {
            db = new ShopDbModelContainer();
        }
        public bool CreateNewOrderItem(Guid productId, int count)
        {
            try
            {
                OrderItem orderItemDb = new OrderItem
                {
                     Count=CurrentOrderItem.Count,
                     ProductId = CurrentOrderItem.ProductId

                };

                db.OrderItems.Add(orderItemDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderItem(Guid id)
        {
            try
            {
                var orderItemDb = db.OrderItems.Find(id);
                if (orderItemDb == null)
                {
                    throw new Exception("Продукт в заказе не найден");
                }
                else
                {
                    db.OrderItems.Remove(orderItemDb);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления продукта из корзины.");
            }
        }
        public OrderItemVM UpdateOrderItem(Guid id, Guid productId, int count)
        {
            var orderItemDb = db.OrderItems.Find(id);
            if (orderItemDb == null)
            {
                throw new Exception("Продукт не найден");
            }
            else
            {
                orderItemDb.Id = id;
                orderItemDb.Count = count;
                orderItemDb.ProductId = productId;
                db.Entry(orderItemDb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new OrderItemVM { Count = orderItemDb.Count, ProductId = orderItemDb.ProductId };
        }
        public List<OrderItemVM> GetOrderItemsListByOrderId(Guid Id)
        {
            var orderItem = db.OrderItems.Where(m => m.OrderId.Equals(CurrentOrder.Id)).ToList();
            if (orderItem.Any())
            {
                var resultList = new List<OrderItemVM>();
                foreach (var orderItemDb in orderItem)
                {
                    resultList.Add(new OrderItemVM { Id = orderItemDb.Id, Count = orderItemDb.Count, ProductId = orderItemDb.ProductId});
                }
                return resultList;
            }
            else
            {
                return new List<OrderItemVM>();
            }
        }
    }
}
