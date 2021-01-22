using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Infrastructure
{
    public class CurrentUser
    {
        public static Guid Id { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Role { get; set; }

    }
}
