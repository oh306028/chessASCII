using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame
{
    public interface IPiece
    {
        bool CanMove(MoveService move, char[,] board);   

        public char Symbol { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public AttackService AttackService { get; }

    }
}
