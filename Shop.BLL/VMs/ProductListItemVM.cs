using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class ProductListItemVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guid Id { get; set; }
    }
}
