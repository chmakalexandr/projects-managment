using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;

namespace ProjectsManagment.Data
{
    public class PMContext : IdentityDbContext
    {
        public PMContext() : base("name=PMContext") { }

        //public DbSet<Employer> Employers { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<ProjectParticipationHistory> ProjectParticipationHistories { get; set; }
        //public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ParticipationType> ParticipationTypes { get; set; }

        public static PMContext Create()
        {
            return new PMContext();
        }
    }
}
