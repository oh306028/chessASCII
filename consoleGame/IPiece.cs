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
        bool CanMove(char[,] board);



    }
}
