using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IOrderItemService
    {
        bool CreateNewOrderItem(Guid productId, int count);
       // OrderItemVM GetOrderItemById(Guid id);
        OrderItemVM UpdateOrderItem(Guid productId, Guid orderId, int coun);
        bool DeleteOrderItem(Guid id);
    }
}
