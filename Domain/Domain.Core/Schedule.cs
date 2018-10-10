using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Schedule
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

        public DateTime DateStart { get; set; }

        public ParticipationType ParticipationType { get; set; }

        public int TimeWorking { get; set; }
    }
}
