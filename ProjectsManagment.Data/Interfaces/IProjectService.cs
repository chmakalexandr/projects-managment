using ProjectsManagment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectService
    {
        IQueryable<Project> SelectQuery(string query, params object[] parameters);

        void Insert(Project project);

        void Update(Project role);

        void Delete(Project role);

        Project FindById(int id);

        Project Find(string predicate);
    }
}
