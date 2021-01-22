using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IManagerService
    {
        bool RegistNewManager(ManagerVM manager);
        bool LogInManager(string login, string passwordHash);
        ManagerVM GetManagerById(Guid id);
        ManagerVM UpdateManager(ManagerVM manager);
        bool DeleteManager(Guid id);
    }
}
