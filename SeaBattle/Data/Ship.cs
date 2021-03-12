using System.Collections.Generic;
using System.Linq;

namespace SeaBattle.Data
{
    public class Ship
    {
        public HashSet<Cell> Cells { get; set; }

        public bool IsAlive => Cells != null && Cells.Any(c => c.IsAlive);
    }
}