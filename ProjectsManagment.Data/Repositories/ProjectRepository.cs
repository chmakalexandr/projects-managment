using Infrastructure.Data;
using ProjectsManagment.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Data.Repositories
{
    public class ProjectRepository:EFGenericRepository<Project>
    {
        //private readonly DbSet<ProjectParticipationHistory> _dbSetParticipationHistories;

        public ProjectRepository(PMContext context) : base(context)
        {

        }
        public Task<List<IEnumerable<User>>> GetAllUsersById(int id)
        {
            return _context.Projects.Where(p => p.Id == id).Select(p => p.ProjectParticipationHistories.Select(u => u.User)).ToListAsync();
        }
                
    }
}
