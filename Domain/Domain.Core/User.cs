﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        private Role Role { get; set; }

        public ICollection<ProjectParticipationHistory> ProjectParticipationHistories { get; set; }

        public User()
        {
            ProjectParticipationHistories = new List<ProjectParticipationHistory>();
        }
    }
}
