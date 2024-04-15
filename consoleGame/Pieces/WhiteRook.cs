using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhiteRook : IPiece, ICastlingPiece
    {
        public char Symbol { get; set; } = 'R';
        public int XPosition { get; set; }
        public int YPosition { get ; set; }

        virtual public AttackService AttackService { get; } = new AttackService('R');
        public bool HasMoved { get; set; } = false;

        public WhiteRook(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        private bool CanMovesInCollumns(MoveService move, char[,] board)        
        {

            if (XPosition == move.XMove && YPosition > move.YMove)
            {
                int i = YPosition - 1;
                do
                {
                    if (board[XPosition, i] != ' ')
                        return false;

                    i--;
                } while (i > move.YMove);
            }



            if (XPosition == move.XMove && YPosition < move.YMove)
            {
                int i = YPosition + 1;
                do
                {
                    if (board[XPosition, i] != ' ')
                        return false;

                    i++;
                } while (i < move.YMove);
            }



            return true;
        }


        private bool CanMovesInRows(MoveService move, char[,] board)
        {   

            if (YPosition == move.YMove && XPosition > move.XMove)
            {
                int i = XPosition - 1;
                do
                {
                    if (board[i, YPosition] != ' ')
                        return false;

                    i--;
                } while (i > move.YMove);
            }



            if (YPosition == move.YMove && XPosition < move.XMove)
            {
                int i = XPosition + 1;
                do
                {
                    if (board[i, YPosition] != ' ')
                        return false;

                    i++;
                } while (i < move.YMove);
            }




            return true;
        }




        public bool CanMove(MoveService move, char[,] board)
        {

            if (XPosition == move.XMove && YPosition == move.YMove)
                return false;

            if (board[move.XMove, move.YMove] != ' ')
            {
               if (!AttackService.CanAttack(move, board))
                   return false;
            }



            if(XPosition == move.XMove)
            {
                if (CanMovesInCollumns(move, board)) { HasMoved = true; return true; }

            }


            if (YPosition == move.YMove)
            {
                if (CanMovesInRows(move, board)) { HasMoved = true; return true; }

            }

            
            return false;
        }
    }
}
