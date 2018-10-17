using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IParticipationTypeService
    {
        IQueryable<ParticipationType> SelectQuery(string query, params object[] parameters);

        void Insert(ParticipationType participationType);

        void Update(ParticipationType participationType);

        void Delete(ParticipationType participationType);

        ParticipationType FindById(int id);

        ParticipationType Find(string predicate);
    }
}
