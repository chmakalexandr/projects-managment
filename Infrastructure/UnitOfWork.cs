using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private PMContext db = new PMContext();
        private EFGenericRepository<User> userRepository;
        private EFGenericRepository<Project> projectRepository;
        private EFGenericRepository<ProjectParticipationHistory> projectParticipationHistoryRepository;
        private EFGenericRepository<ProjectRole> projectRoleRepository;
        private EFGenericRepository<Role> roleRepository;
       
        public EFGenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new EFGenericRepository<User>(db);
                return userRepository;
            }
        }

        public EFGenericRepository<Role> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new EFGenericRepository<Role>(db);
                return roleRepository;
            }
        }


        public EFGenericRepository<Project> ProjectRepository
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new EFGenericRepository<Project>(db);
                return projectRepository;
            }
        }

        public EFGenericRepository<ProjectParticipationHistory> ProjectParticipationHistoryRepositoriy
        {
            get
            {
                if (projectParticipationHistoryRepository == null)
                    projectParticipationHistoryRepository = new EFGenericRepository<ProjectParticipationHistory>(db);
                return projectParticipationHistoryRepository;
            }
        }

        public EFGenericRepository<ProjectRole> ProjectRoleRepository
        {
            get
            {
                if (projectRoleRepository == null)
                    projectRoleRepository = new EFGenericRepository<ProjectRole>(db);
                return projectRoleRepository;
            }
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
