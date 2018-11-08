using ProjectsManagment.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Entity.ViewModels
{
    
    public class ProjectParticipationHistoryViewModel
    {
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
                       
        public DateTime ActuallyDayEnd { get; set; }
                
        public User User { get; set; }
               
        public Project Project { get; set; }
                
        public ProjectRole ProjectRole { get; set; }

        public ParticipationType ParticipationType { get; set; }

        public double percentageEmployment { get; set; }

        public Schedule Schedule { get; set; }
    }
        
}
