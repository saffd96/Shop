﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.VMs
{
    public class OrderItemVM
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public Guid Id { get; set; }
    }
}
