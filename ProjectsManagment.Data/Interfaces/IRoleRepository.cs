using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoleList();
        Role GetRole(int id);
        void Create(Role item);
        void Update(Role item);
        void Delete(int id);
        void Save();
    }
}
