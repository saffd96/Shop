using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class OrderVM
    {
        public Guid BuyerId { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
