using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IParticipationTypeRepository
    {
        IEnumerable<ParticipationType> GetParticipationTypeList();
        ParticipationType GetParticipationType(int id);
        void Create(ParticipationType item);
        void Update(ParticipationType item);
        void Delete(int id);
        void Save();
    }
}
