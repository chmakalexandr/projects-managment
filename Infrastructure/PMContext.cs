using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Infrastructure.Data
{
    public class PMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ParticipationType> ParticipationTypes { get; set; }
    }
}
