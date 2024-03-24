using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhiteKnight : IPiece
    {
        public char Symbol { get; set; } = 'N';
        public int XPosition { get ; set ; }
        public int YPosition { get ; set; }

        public virtual AttackService AttackService { get; } = new AttackService('N');

        public WhiteKnight(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }


        public bool CanMove(MoveService move, char[,] board)
        {

            if(move.XMove == XPosition && move.YMove == YPosition)
                return false;


            if (board[move.XMove, move.YMove] != ' ' && !AttackService.CanAttack(move, board))           
                return false;
            


            if(board[move.XMove, move.YMove] == ' ' || AttackService.CanAttack(move, board))
            {
                if (XPosition - 2 == move.XMove && YPosition - 1 == move.YMove || XPosition - 2 == move.XMove && YPosition + 1 == move.YMove)
                    return true;

                if (XPosition + 2 == move.XMove && YPosition + 1 == move.YMove || XPosition + 2 == move.XMove && YPosition - 1 == move.YMove)
                    return true;

                if (XPosition - 1 == move.XMove && YPosition - 2 == move.YMove || XPosition + 1 == move.XMove && YPosition - 2 == move.YMove)
                    return true;

                if (XPosition + 1 == move.XMove && YPosition + 2 == move.YMove || XPosition - 1 == move.XMove && YPosition + 2 == move.YMove)
                    return true;
            }



            return false;

        }
    }
}
