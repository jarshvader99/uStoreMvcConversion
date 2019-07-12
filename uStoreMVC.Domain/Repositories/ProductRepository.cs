using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStoreMvc.data.EF;
using System.Data.Entity;

namespace uStoreMVC.Domain.Repositories
{
    public class ProductRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Find(int? id)
        {
            return db.Products.Find(id);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Product product)
        {
            db.Authors.Add(product);
            db.SaveChanges();
        }

        public void Remove(Product product)
        {
            db.Authors.Remove(product);
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
