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
    public class ProjectParticipationHistoryRepository : IProjectParticipationHistoryRepository
    {
        private PMContext db;

        public ProjectParticipationHistoryRepository()
        {
            this.db = new PMContext();
        }

        public ProjectParticipationHistoryRepository(PMContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProjectParticipationHistory> GetProjectParticipationHistoryList()
        {
            return db.ProjectParticipationHistories.ToList();
        }

        public ProjectParticipationHistory GetProjectParticipationHistory(int id)
        {
            return db.ProjectParticipationHistories.Find(id);
        }

        public void Create(ProjectParticipationHistory schedule)
        {
            db.ProjectParticipationHistories.Add(schedule);
        }

        public void Update(ProjectParticipationHistory schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProjectParticipationHistory schedule = db.ProjectParticipationHistories.Find(id);
            if (schedule != null)
                db.ProjectParticipationHistories.Remove(schedule);
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
