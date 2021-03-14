using System.Collections.Generic;
using System.Linq;

namespace SeaBattle.Data
{
    public class Ship
    {
        public List<Cell> Cells { get; set; } = new List<Cell>();

        public bool IsDestroyed => Cells != null && Cells.All(c => !c.IsAlive);

        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
            cell.Ship = this;
        }
    }
}