using Proje.DataAccess.Abstract;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            using (var appDbCcontext = new AppDbContext())
            {
                appDbCcontext.Products.Add(product);
                appDbCcontext.SaveChanges();
                return product;
            }
        }

        public void DeleteProduct(int id)
        {
            using (var appDbCcontext = new AppDbContext())
            {
                var deletedProduct = GetProductById(id);
                appDbCcontext.Products.Remove(deletedProduct);
                appDbCcontext.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using(var appDbCcontext= new AppDbContext())
            {
                return appDbCcontext.Products.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (var appDbCcontext = new AppDbContext())
            {
                return appDbCcontext.Products.Find(id);
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (var appDbCcontext = new AppDbContext())
            {
                appDbCcontext.Products.Update(product);
                appDbCcontext.SaveChanges();
                return product;
            }
        }
    }
}
