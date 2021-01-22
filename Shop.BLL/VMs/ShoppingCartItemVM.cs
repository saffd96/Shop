using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class ShoppingCartItemVM
    {
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public int Count { get; set; }
    }
}
