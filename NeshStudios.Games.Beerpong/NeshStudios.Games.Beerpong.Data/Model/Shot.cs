using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public class Shot
    {
        public int ShotID { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }

        public Game Game { get; set; }

        [ForeignKey("Rack")]
        public int? RackID { get; set; }

        public virtual Rack Rack { get; set; }

        [ForeignKey("Cup")]
        public int? CupID { get; set; }

        public virtual Cup Cup { get; set; }

        public virtual OffensiveShotResult OffensiveShotResult { get; set; }

        public virtual DefensiveShotResult DefensiveShotResult { get; set; }
    }
}
