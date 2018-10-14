using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private PMContext db;

        public UserRepository()
        {
            this.db = new PMContext();
        }

        public UserRepository(PMContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetUserList()
        {
            return db.Users.ToList();
        }

        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User book)
        {
            db.Users.Add(book);
        }

        public void Update(User book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User book = db.Users.Find(id);
            if (book != null)
                db.Users.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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

