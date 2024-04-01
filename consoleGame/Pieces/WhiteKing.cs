using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhiteKing : ICastlingPiece, IPiece 
    {
        public char Symbol { get; set; } = 'K';
        public int XPosition { get; set; }
        public int YPosition { get ; set ; }
        public bool HasMoved { get; set; } = false;
        public virtual AttackService AttackService { get; } = new AttackService('K');


        public WhiteKing(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        private bool ValidMove(MoveService move, char[,] board)
        {
            if (board[move.XMove, move.YMove] == ' ' || (board[move.XMove, move.YMove] != ' ' && AttackService.CanAttack(move, board))) return true;

            return false;
        }

        public bool CanMove(MoveService move, char[,] board)
        {

            if (move.XMove == XPosition && move.YMove == YPosition)
                return false;


            if (board[move.XMove, move.YMove] != ' ' && !AttackService.CanAttack(move, board))
                return false;
         

                if (XPosition == move.XMove && (YPosition + 1 == move.YMove || YPosition - 1 == move.YMove))
                {
                    if (ValidMove(move,board)) return true;
                }
                    

                if (YPosition == move.YMove && (XPosition + 1 == move.XMove || XPosition - 1 == move.XMove))
                {
                   if (ValidMove(move, board)) return true;
                }


                if (Math.Abs(XPosition - move.XMove) == 1 && Math.Abs(YPosition - move.YMove) == 1)
                {
                    if (ValidMove(move, board)) return true;
                }
            
                      

            // for castling method !!
            //
            //
            
               return false;

        }

    }
}
