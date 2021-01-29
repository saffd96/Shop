using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class OrderListItemVM
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}
