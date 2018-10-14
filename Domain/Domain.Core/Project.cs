using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime Datestart { get; set; }

        [Required]
        public DateTime Dateend { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<ProjectParticipationHistory> ProjectParticipationHistories { get; set; }

        public Project()
        {
            ProjectParticipationHistories = new List<ProjectParticipationHistory>();
        }
    }
}
