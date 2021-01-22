using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IOrderService
    {
        OrderVM CreateNewOrder(Guid buyerId);
        OrderVM GetOrderById(Guid id);
        OrderVM UpdateOrder(Guid buyerId);
        bool DeleteOrder(Guid id);
    }
}
