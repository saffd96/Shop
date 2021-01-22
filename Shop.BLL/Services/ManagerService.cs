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
    class ManagerService : IManagerService
    {
        private ShopDbModelContainer db;
        public ManagerService()
        {
            db = new ShopDbModelContainer();
        }

        public bool DeleteManager(Guid id)
        {
            throw new NotImplementedException();
        }

        public ManagerVM GetManagerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool LogInManager(string login, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public bool RegistNewManager(ManagerVM manager)
        {
            try
            {
                Manager managerDb = new Manager
                {
                    Login = manager.Login,
                    PasswordHash = manager.PasswordHash,
                    Name = manager.Name,
                    PhoneNumber = manager.PhoneNumber,
                    Surname = manager.Surname,
                };

                db.Managers.Add(managerDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ManagerVM UpdateManager(ManagerVM manager)
        {
            throw new NotImplementedException();
        }
    }
}
