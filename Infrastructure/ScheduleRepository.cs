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
    class ScheduleRepository : IScheduleRepository
    {
        private PMContext db;

        public ScheduleRepository()
        {
            this.db = new PMContext();
        }

        public IEnumerable<Schedule> GetScheduleList()
        {
            return db.Schedules.ToList();
        }

        public Schedule GetSchedule(int id)
        {
            return db.Schedules.Find(id);
        }

        public void Create(Schedule schedule)
        {
            db.Schedules.Add(schedule);
        }

        public void Update(Schedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule != null)
                db.Schedules.Remove(schedule);
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
