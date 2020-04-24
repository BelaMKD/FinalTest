using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IProductRepository
    {
        Product CreateProduct(Product product);
        IEnumerable<Product> GetProducts(int id);
        int Commit();
    }
}
