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
    public class ProjectRoleRepository : IProjectRoleRepository
    {
        private PMContext db;

        public ProjectRoleRepository()
        {
            this.db = new PMContext();
        }

        public ProjectRoleRepository(PMContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProjectRole> GetProjectRoleList()
        {
            return db.ProjectRoles.ToList();
        }

        public ProjectRole GetProjectRole(int id)
        {
            return db.ProjectRoles.Find(id);
        }

        public void Create(ProjectRole projectRole)
        {
            db.ProjectRoles.Add(projectRole);
        }

        public void Update(ProjectRole projectRole)
        {
            db.Entry(projectRole).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProjectRole projectRole = db.ProjectRoles.Find(id);
            if (projectRole != null)
                db.ProjectRoles.Remove(projectRole);
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
