﻿using System;
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

            var board = new char[Rows, Collumns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Collumns; j++)
                {
                    board[i, j] = ' ';
                }
            }


            board[1, 0] = '1';
            board[2, 0] = '2';
            board[3, 0] = '3';
            board[4, 0] = '4';
            board[5, 0] = '5';
            board[6, 0] = '6';
            board[7, 0] = '7';
            board[8, 0] = '8';


            board[0, 1] = 'A';
            board[0, 2] = 'B';
            board[0, 3] = 'C';
            board[0, 4] = 'D';
            board[0, 5] = 'E';
            board[0, 6] = 'F';
            board[0, 7] = 'G';
            board[0, 8] = 'H';

            board[1, 1] = 'r';
            board[1, 8] = 'r';

            board[1, 2] = 'n';
            board[1, 7] = 'n';

            board[1, 3] = 'b';
            board[1, 6] = 'b';

            board[1, 4] = 'q';
            board[1, 5] = 'k';


            board[8, 1] = 'R';
            board[8, 8] = 'R';

            board[8, 2] = 'N';
            board[8, 7] = 'N';

            board[8, 3] = 'B';
            board[8, 6] = 'B';

            board[8, 4] = 'Q';
            board[8, 5] = 'K';



            for (int i = 1; i < Collumns; i++)
            {
                board[2, i] = 'p';
            }


            for (int i = 1; i < Collumns; i++)
            {
                board[7, i] = 'P';
            }


            return board; 
        }

        public static void ShowBoard(char[,] board)
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Collumns; j++)
                {
                    Console.Write(board[i,j]);                   
                }

                Console.WriteLine();
            }

        }


    }
}
