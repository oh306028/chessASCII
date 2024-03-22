using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhitePawn : Piece
    {

        public WhitePawn(int xPos, int yPos)
        {
            Symbol = 'P';
            XPosition = xPos;
            YPosition = yPos;
        }

        public override bool CanMove(MoveService move, char[,] board)
        {

           


            if (board[move.XMove, move.YMove] != ' ')
            {
                if (AttackService.CanAttack(move))
                    return true;
                    


            }

            // moving





            return false; 
            
        }


    }
}
