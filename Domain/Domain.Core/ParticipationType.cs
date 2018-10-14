using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public enum ParticipationTypeEnum
    {
        Percent = 1,
        Days = 2
    }
    public class ParticipationType
    {
        
        [Required]
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
