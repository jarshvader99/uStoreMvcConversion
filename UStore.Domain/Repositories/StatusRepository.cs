using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStore.data1.EF;

namespace UStore.Domain.Repositories
{
    public class StatusRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Status> Get()
        {
            return db.Statuses.ToList();
        }

        public Status Find(int? id)
        {
            return db.Statuses.Find(id);
        }

        public void Update(Status status)
        {
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Status status)
        {
            db.Statuses.Add(status);
            db.SaveChanges();
        }

        public void Remove(Status status)
        {
            db.Statuses.Remove(status);
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
