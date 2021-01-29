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
    public class ManagerService : IManagerService
    {
        private ShopDbModelContainer db;
        public ManagerService()
        {
            db = new ShopDbModelContainer();
        }

        public bool DeleteManager(Guid id)
        {
            try
            {
                var managerDb = db.Managers.Find(id);
                if (managerDb == null)
                {
                    throw new Exception("Менеджер не найден");
                }
                else
                {
                    db.Managers.Remove(managerDb);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления менеджера.");
            }
        }
        public bool LogInManager(string login, string passwordHash)
        {
            var managerDb = db.Managers.Where(m => m.Login.Equals(login) && m.PasswordHash.Equals(passwordHash)).SingleOrDefault();
            if (managerDb == null) { return false; }
            else
            {
                CurrentUser.Id = managerDb.Id;
                CurrentUser.Name = managerDb.Name;
                CurrentUser.Surname = managerDb.Surname;
                CurrentUser.Role = managerDb.Role;
                return true;
            }
        }

        public bool RegistNewManager(ManagerVM manager)
        {
            try
            {
                if (db.Managers.Select(m => m.Login).Contains(manager.Login)) { return false; }

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
            var managerDb = db.Managers.Find(manager);
            if (managerDb == null)
            {
                throw new Exception("Менеджер не найден");
            }
            else
            {
                managerDb.Login = manager.Login;
                managerDb.Name = manager.Name;
                managerDb.PasswordHash = manager.PasswordHash.GetHashCode().ToString();
                managerDb.PhoneNumber = manager.PhoneNumber;
                managerDb.Surname = manager.Surname;
                db.Entry(managerDb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new ManagerVM
            {
                Login = managerDb.Login,
                Name = managerDb.Name,
                PasswordHash = managerDb.PasswordHash,
                PhoneNumber = managerDb.PhoneNumber,
                Surname = managerDb.Surname
            };
        }
    }
}
