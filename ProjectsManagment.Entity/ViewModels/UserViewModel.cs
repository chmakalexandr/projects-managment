using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Entity.ViewModels
{
    public class UserViewModel
    {
        public string Firstname { get; set; }
               
        public string Middlename { get; set; }
               
        public string Lastname { get; set; }

        public string Email { get; set; }
    }

    public class CreateUserViewModel
    {
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }

    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
                
        public string LastName { get; set; }

        public string Email { get; set; }
    }


}
