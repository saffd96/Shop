using Shop.DbFiles;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleHelper = new ConsoleHelper();
            consoleHelper.ShowMainPage();
        }
    }
}
