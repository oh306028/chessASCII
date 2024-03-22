using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public abstract class Piece : IPiece
    {
        abstract public bool CanMove(char[,] board);

        public int XPosition { get; set; }
        public int YPosition { get; set; }
 

    }
}
