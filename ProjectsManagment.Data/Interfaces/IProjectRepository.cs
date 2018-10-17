using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjectList();
        Project GetProject(int id);
        void Create(Project item);
        void Update(Project item);
        void Delete(int id);
        void Save();
    }
}
