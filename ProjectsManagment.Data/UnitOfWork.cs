using ProjectsManagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Entity;
using ProjectsManagment.Data.Repositories;
using System.Data.Entity.Validation;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private PMContext context;
        private UserRepository userRepository;
        private ProjectRepository projectRepository;
        private ProjectParticipationHistoryRepository projectParticipationHistoryRepository;
        private RoleRepository roleRepository;

        public UnitOfWork()
        {
            context = new PMContext();
        }
        
        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        
        public ProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(context);
                return projectRepository;
            }
        }
        public ProjectParticipationHistoryRepository ProjectParticipationHistories
        {
            get
            {
                if (projectParticipationHistoryRepository == null)
                    projectParticipationHistoryRepository = new ProjectParticipationHistoryRepository(context);
                return projectParticipationHistoryRepository;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }
        

        public void Save()
        {
            
            try
            {

                context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.Write("Object: " + validationError.Entry.Entity.ToString());
                    Console.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.Write(err.ErrorMessage + " ");
                        }
                }
            }
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
