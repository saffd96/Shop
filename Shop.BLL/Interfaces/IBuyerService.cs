using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IBuyerService
    {
        bool RegistNewBuyer(BuyerVM buyer);
        bool LogInBuyer(string login, string passwordHash);
        BuyerVM GetBuyerById(Guid id);
        BuyerVM UpdateBuyer(BuyerVM buyer);
        bool DeleteBuyer(Guid id);
    }
}
