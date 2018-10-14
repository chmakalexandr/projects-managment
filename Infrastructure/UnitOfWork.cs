using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private PMContext db = new PMContext();
        private UserRepository userRepository;
        private ProjectRepository projectRepository;
        private ProjectParticipationHistoryRepository projectParticipationHistoryRepository;
        private ProjectRoleRepository projectRoleRepository;
        private RoleRepository roleRepository;

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }


        public ProjectRepository ProjectRepositories
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }

        public ProjectParticipationHistoryRepository ProjectParticipationHistoryRepositories
        {
            get
            {
                if (projectParticipationHistoryRepository == null)
                    projectParticipationHistoryRepository = new ProjectParticipationHistoryRepository(db);
                return projectParticipationHistoryRepository;
            }
        }

        public ProjectRoleRepository ProjectRoleRepositories
        {
            get
            {
                if (projectRoleRepository == null)
                    projectRoleRepository = new ProjectRoleRepository(db);
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
