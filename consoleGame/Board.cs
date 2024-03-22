using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame
{
    public static class Board
    {
        public static int Rows { get; } = 9;
        public static int Collumns { get; } = 9;

        public static char[,] InitGrid()
        {

            return new char[Rows,Collumns]; 
        }


    }
}
