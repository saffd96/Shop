using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Infrastructure
{
    class CurrentOrderItem
    {
        public static Guid ProductId { get; set; }
        public static int Count { get; set; }
        public static Guid OrderId { get; set; }
    }
}
