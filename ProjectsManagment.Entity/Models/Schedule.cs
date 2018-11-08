using ProjectsManagment.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Entity.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ProjectParticipationHistory ProjectParticipationHistory { get; set; }

        public WorkingDaysEnum WorkingDays { get; set; }
        
    }
}
