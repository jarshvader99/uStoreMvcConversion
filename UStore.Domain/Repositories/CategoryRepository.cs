using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStore.data1.EF;

namespace UStore.Domain.Repositories
{
    public class CategoryRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Find(int? id)
        {
            return db.Categories.Find(id);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Remove(Category category)
        {
            db.Categories.Remove(category);
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
