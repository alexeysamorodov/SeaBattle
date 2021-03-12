using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaBattle.Data
{
    public class Matrix
    {
        public int Size { get; set; }

        public Cell[,] Cells { get; set; }

        public bool Shots { get; set; }
    }
}
