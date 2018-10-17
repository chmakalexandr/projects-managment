using ProjectsManagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Entity;


namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private PMContext context;
        private EFGenericRepository<User> userRepository;
        private EFGenericRepository<Project> projectRepository;
        private EFGenericRepository<ProjectParticipationHistory> projectParticipationHistoryRepository;
        private EFGenericRepository<ProjectRole> projectRoleRepository;
        private EFGenericRepository<Role> roleRepository;
        public UnitOfWork()
        {
            context = new PMContext();
        }
        
        public IGenericRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new EFGenericRepository<User>(context);
                return userRepository;
            }
        }
        public IGenericRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new EFGenericRepository<Role>(context);
                return roleRepository;
            }
        }
        public IGenericRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new EFGenericRepository<Project>(context);
                return projectRepository;
            }
        }
        public IGenericRepository<ProjectParticipationHistory> ProjectParticipationHistories
        {
            get
            {
                if (projectParticipationHistoryRepository == null)
                    projectParticipationHistoryRepository = new EFGenericRepository<ProjectParticipationHistory>(context);
                return projectParticipationHistoryRepository;
            }
        }
        public IGenericRepository<ProjectRole> ProjectRoles
        {
            get
            {
                if (projectRoleRepository == null)
                    projectRoleRepository = new EFGenericRepository<ProjectRole>(context);
                return projectRoleRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
