using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class OrderItemVM
    {
        public Guid ProductID { get; set; }
        public int Count { get; set; }
    }
}
