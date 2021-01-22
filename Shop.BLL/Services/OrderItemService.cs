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
    class OrderItemService : IOrderItemService
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
            throw new NotImplementedException();
        }

        public OrderItemVM GetOrderItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderItemVM UpdateOrderItem(Guid productId, Guid orderId, int coun)
        {
            throw new NotImplementedException();
        }
    }
}
