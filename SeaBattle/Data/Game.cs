﻿using System.Collections.Generic;
using System.Linq;

namespace SeaBattle.Data
{
    public class Game
    {
        public GameState State { get; set; }

        public Matrix Matrix { get; set; }

        public List<Ship> Ships { get; set; } = new List<Ship>();

        public bool AreAllShipsDestroyed => Ships.Any() && Ships.All(s => s.IsDestroyed);

        public void Clear()
        {
            State = GameState.NotStarted;
            Matrix = null;
            Ships = new List<Ship>();
        }

        public void ResetMatrixWithShips()
        {
            Matrix = new Matrix(Matrix.Size);
            Ships = new List<Ship>();
        }
    }
}
