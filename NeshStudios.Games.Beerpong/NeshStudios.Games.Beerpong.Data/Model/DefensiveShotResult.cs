using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public enum DefenceType
    {
        Finger,
        Blow,
        BounceBlock,
        Smack,
        Error,
    }

    public class DefensiveShotResult
    {
        private DefenceType _defence;
        private string _defenceType;

        [ForeignKey("Shot")]
        public int ShotID { get; set; }

        public virtual Shot Shot { get; set; }

        [ForeignKey("TeamMember")]
        public int? TeamMemberID { get; set; }

        public virtual TeamMember TeamMember { get; set; }

        [NotMapped]
        public DefenceType Defence
        {
            get 
            { 
                return _defence;
            }
            set 
            { 
                _defence = value;
                this.DefenceType = _defence.ToString();
            }
        }

        protected internal string DefenceType
        {
            get
            {
                return _defenceType;
            }
            set
            {
                _defenceType = value;
                _defence = (DefenceType)Enum.Parse(typeof(DefenceType), value);
            }
        }
    }
}
