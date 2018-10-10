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
    class ParticipationTypeRepository : IParticipationTypeRepository
    {
        private PMContext db;

        public ParticipationTypeRepository() 
        {
            this.db = new PMContext();
        }

        public IEnumerable<ParticipationType> GetParticipationTypeList()
        {
            return db.ParticipationTypes.ToList();
        }

        public ParticipationType GetParticipationType(int id)
        {
            return db.ParticipationTypes.Find(id);
        }

        public void Create(ParticipationType participationType)
        {
            db.ParticipationTypes.Add(participationType);
        }

        public void Update(ParticipationType participationType)
        {
            db.Entry(participationType).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ParticipationType participationType = db.ParticipationTypes.Find(id);
            if (participationType != null)
                db.ParticipationTypes.Remove(participationType);
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
