using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public enum  WorkingDaysEnum {Mon, Tue, Wed, Thu, Fri}
    
    public class ProjectParticipationHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

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
        public Object TimeWorking
        {
            get
            {
                return this.TimeWorking;

            }
            set
            {
                if (this.ParticipationType.ToString() == "Percent")
                {
                    TimeWorking = (int) value;
                }
                else
                {
                    TimeWorking = value.ToString();
                }

            }
        }
    }
}
