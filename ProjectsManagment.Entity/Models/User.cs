using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectsManagment.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }

        [MaxLength(100)]
        public string Middlename { get; set; }

        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public int? RoleId { get; set; }
        private Role Role { get; set; }

        public ICollection<ProjectParticipationHistory> ProjectParticipationHistories { get; set; }

        public User()
        {
            ProjectParticipationHistories = new List<ProjectParticipationHistory>();
        }
    }
}
