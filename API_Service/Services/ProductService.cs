using API_Service.DAL;
using API_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Service.Services
{
    public interface IProductService
    {
        IList<Product> GelAll();
        Product GetById(int ProductId);
        Product PostProduct(Product product);

        
    }

    public class ProductService : IProductService
    {
        private ApplicationContext db;
        public ProductService(ApplicationContext db)
        {
            this.db = db;

        }
        public IList<Product> GelAll()
        {

            return db.Products.ToList();

        }

        public Product GetById(int ProductId)
        {
            return db.Products.Where(w => w.ProductId == ProductId).FirstOrDefault();
        }

        public Product PostProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }
    }
}
