using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public class Cup
    {
        [Key]
        public int CupID { get; set; }
        public int Order { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Radius { get; set; }

        [ForeignKey("Rack")]
        public int RackID { get; set; }

        public virtual Rack Rack { get; set; }
    }
}
