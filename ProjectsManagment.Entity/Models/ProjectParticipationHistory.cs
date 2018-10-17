using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Entity
{
    public enum  WorkingDaysEnum {Mon, Tue, Wed, Thu, Fri}
    
    public class ProjectParticipationHistory
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? ProjectRoleId { get; set; }
        public ProjectRole ProjectRole { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date start participation")]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date end participation")]
        public DateTime DateEnd { get; set; }

        [Required]
        public ParticipationType ParticipationType { get; set; }

        [Required]
        public string TimeWorking { get; set; }
               
        
    }
}
