using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public class TeamMember
    {
        public int TeamMemberID { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        [ForeignKey("Player")]
        public int PlayerID { get; set; }

        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    }
}
