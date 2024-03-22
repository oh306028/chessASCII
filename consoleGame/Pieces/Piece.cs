using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class Piece : IPiece
    {
        virtual public bool CanMove(MoveService move, char[,] board)
        {
            return false;
        }

        public AttackService AttackService { get; set; } = new AttackService();
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Symbol { get; set; }

    }
}
