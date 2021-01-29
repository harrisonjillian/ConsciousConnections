using ConsciousConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Contracts
{
    public interface IProductService
    {
        //Guid userId { get; set; }
        bool CreateProduct(ProductCreate model);
        IEnumerable<ProductListItem> GetProducts();
        ProductDetail GetProductById(int id);
        bool UpdateProduct(ProductEdit model);
        bool DeleteProduct(int productId);

    }
}
