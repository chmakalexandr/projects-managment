using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public enum ProjectRoleEnum
    {
        Undefined = 0,
        ProjectManager = 1,
        Programmer = 2,
        Tester = 3

    }
    public class ProjectRole
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
                Title = (ProjectRoleEnum)value;
            }
        }

        [EnumDataType(typeof(ProjectRoleEnum))]
        public ProjectRoleEnum Title { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
