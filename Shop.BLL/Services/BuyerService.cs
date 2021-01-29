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
    public class BuyerService : IBuyerService
    {
        private ShopDbModelContainer db;

        public BuyerService()
        {
            db = new ShopDbModelContainer();
        }

        public bool DeleteBuyer(Guid id)
        {
            try
            {
                var buyerDb = db.Buyers.Find(id);
                if (buyerDb == null)
                {
                    throw new Exception("Покупатель не найден");
                }
                else
                {
                    db.Buyers.Remove(buyerDb);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                throw new Exception("Ошибка удаления покупателя.");
            }
        }

        public BuyerVM GetBuyerById(Guid id)
        {
            var buyerDb = db.Buyers.Find(id);
            if (buyerDb == null)
            {
                throw new Exception("Покупатель не найден");
            }
            else
            {
                return new BuyerVM { Adress = buyerDb.Adress, DateOfBirth = buyerDb.DateOfBirth, Login = buyerDb.Login, Name = buyerDb.Name, PhoneNumber = buyerDb.PhoneNumber, Surname = buyerDb.Surname };
            }
        }

        public bool LogInBuyer(string login, string passwordHash)
        {
            var buyerDb = db.Buyers.Where(m => m.Login.Equals(login) && m.PasswordHash.Equals(passwordHash)).SingleOrDefault();
            if (buyerDb == null) { return false; }
            else
            {
                CurrentUser.Id = buyerDb.Id;
                CurrentUser.Name = buyerDb.Name;
                CurrentUser.Surname = buyerDb.Surname;
                CurrentUser.Role = buyerDb.Role;
                return true;
            }
        }
        public bool RegistNewBuyer(BuyerVM buyer)
        {
            try
            {
                if (db.Buyers.Select(m => m.Login).Contains(buyer.Login)) { return false; }

                Buyer buyerDb = new Buyer
                {
                    Login = buyer.Login,
                    PasswordHash = buyer.PasswordHash,
                    Name = buyer.Name,
                    PhoneNumber = buyer.PhoneNumber,
                    Adress = buyer.Adress,
                    Surname = buyer.Surname,
                    DateOfBirth = buyer.DateOfBirth,
                    DateOfRegister = DateTime.Now
                };

                db.Buyers.Add(buyerDb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BuyerVM UpdateBuyer(BuyerVM buyer)
        {
            var buyerDb = db.Buyers.Find(buyer);
            if (buyerDb == null)
            {
                throw new Exception("Покупатель не найден");
            }
            else
            {
                buyerDb.Name = buyer.Name;
                buyerDb.Login = buyer.Login;
                buyerDb.Name = buyer.Name;
                buyerDb.PasswordHash = buyer.PasswordHash.GetHashCode().ToString();
                buyerDb.PhoneNumber = buyer.PhoneNumber;
                buyerDb.Surname = buyer.Surname;
                buyerDb.DateOfBirth = buyer.DateOfBirth;

                db.Entry(buyerDb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new BuyerVM { 
                Adress = buyerDb.Adress,
                DateOfBirth = buyerDb.DateOfBirth,
                Login = buyerDb.Login,
                Name = buyerDb.Name,
                PasswordHash = buyerDb.PasswordHash,
                PhoneNumber = buyerDb.PhoneNumber,
                Surname = buyerDb.Surname 
            };
        }
    }
}
