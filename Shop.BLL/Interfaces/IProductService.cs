using Shop.BLL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    interface IProductService
    {
        //CRUD - Create, Read, Update, Delete
        bool CreateNewProduct(ProductVM product);
        ProductVM GetProductById(Guid id);
        ProductVM UpdateProduct(ProductVM product);
        bool DeleteProduct(Guid id);
        List<ProductListItemVM> GetProductListFromShop();

    }
}
