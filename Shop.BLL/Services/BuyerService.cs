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
    class BuyerService : IBuyerService
    {
        private ShopDbModelContainer db;

        public BuyerService()
        {
            db = new ShopDbModelContainer();
        }

        public bool DeleteBuyer(Guid id)
        {
            throw new NotImplementedException();
        }

        public BuyerVM GetBuyerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool LogInBuyer(string login, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public bool RegistNewBuyer(BuyerVM buyer)
        {
            try
            {
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
            throw new NotImplementedException();
        }
    }
}
