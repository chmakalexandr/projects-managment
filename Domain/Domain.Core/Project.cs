using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }
        public string Status { get; set; }

        public ICollection<User> Users { get; set; }

        public Project()
        {
            Users = new List<User>();
        }
    }
}
