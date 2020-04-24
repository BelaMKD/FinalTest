using Core;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql
{
    public class ProductRepository : IProductRepository
    {
        private readonly UjpDbContext dbContext;

        public ProductRepository(UjpDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Product CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            return product;
        }

        public IEnumerable<Product> GetProducts(int id)
        {
            return dbContext.Products.ToList();
        }
    }
}
