using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public class Rack
    {
        public int RackID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Cup> Cups { get; set; }
    }
}
