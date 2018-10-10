using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
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
