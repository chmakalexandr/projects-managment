using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> SelectQuery(string query, params object[] parameters);

        void Insert(User user);

        void Update(User user);

        void Delete(User entity);

        User FindById(int id);

        User Find(string predicate);

        
        void AddToProject(ProjectParticipationHistory participationHistory);
        
        void RemoveFromProject(ProjectParticipationHistory participationHistory);
        //Task<List<IEnumerable<Project>>> GetAllProjectsByUserId(int id);
    }
}
