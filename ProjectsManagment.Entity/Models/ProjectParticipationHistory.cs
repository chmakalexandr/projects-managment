using ProjectsManagment.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Entity
{
     
    public class ProjectParticipationHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date actually end participation")]
        public DateTime ActuallyDayEnd { get; set; }

        [Required]
        public ParticipationType ParticipationType { get; set; }

        public double percentageEmployment { get; set; }

        public Schedule Schedule { get; set; }
    }
}
