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
    public class ParticipationType
    {
        
        public virtual int Id
        {
            get
            {
                return (int) this.Type;

            }
            set
            {
                Type = (ParticipationTypeEnum)value;
            }
        }

        [EnumDataType(typeof(ParticipationTypeEnum))]
        public ParticipationTypeEnum Type { get; set; }
    }
}
