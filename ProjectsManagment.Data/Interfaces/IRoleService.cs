using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IRoleService
    {
        IQueryable<Role> SelectQuery(string query, params object[] parameters);

        void Insert(Role role);

        void Update(Role role);

        void Delete(Role role);

        Role FindById(int id);

        Role Find(string predicate);
    }
}
