using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public enum NameRoleEnum
    {
        Admin = 1,
        ResourceManager = 2,
        Employe = 3

    }
    public class Role
    {
        [Required]
        public virtual int Id
        {
            get
            {
                return (int)this.Title;

            }
            set
            {
                Title = (NameRoleEnum)value;
            }
        }

        [EnumDataType(typeof(NameRoleEnum))]
        public NameRoleEnum Title { get; set; }
        
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
