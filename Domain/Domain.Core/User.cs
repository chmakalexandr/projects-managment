using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
     
        private Role Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public User()
        {
            Projects = new List<Project>();
        }
    }
}
