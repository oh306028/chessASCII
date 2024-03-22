using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhitePawn : IPiece
    {

        public WhitePawn(int xPos, int yPos)
        {
            XPosition = xPos;
            YPosition = yPos;
        }

        public char Symbol { get; set; } = 'P';
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public AttackService AttackService { get; } = new AttackService();
     

        public bool CanMove(MoveService move, char[,] board)
        {
           

            if (board[move.XMove,move.YMove] != ' ')
            {
                if (!AttackService.CanAttack(move))
                    return false;
                
                if(XPosition - 1 == move.XMove && (YPosition + 1 == move.YMove || YPosition - 1 == move.YMove))
                     return true;

            }


            if (move.XMove == XPosition)
                return false;


            if (XPosition == 7 && move.XMove == 5)
                return true;


            if (XPosition - 1 == move.XMove)
                return true;



            return false; 
            
        }


    }
}
