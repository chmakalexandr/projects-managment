using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetScheduleList();
        Schedule GetSchedule(int id);
        void Create(Schedule item);
        void Update(Schedule item);
        void Delete(int id);
        void Save();
    }
}
