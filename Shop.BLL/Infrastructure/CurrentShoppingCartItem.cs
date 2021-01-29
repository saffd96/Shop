using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Infrastructure
{
    class CurrentShoppingCartItem
    {
        public static Guid Id { get; set; }
        public static Guid ShoppingCartId { get; set; }
        public static Guid ProductId { get; set; }
        public static int Count { get; set; }
    }
}
