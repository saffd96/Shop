using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Infrastructure
{
    public class CurrentProduct
    {
        public static Guid Id { get; set; }
        public static string Name { get; set; }
        public static string Description { get; set; }
        public static decimal Price { get; set; }
        public static int Amount { get; set; }

    }
}
