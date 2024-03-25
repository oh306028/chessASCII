using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhiteQueen : IPiece
    {
        public char Symbol { get; set; } = 'Q';
        public int XPosition { get ; set; }
        public int YPosition { get; set ; }

        public virtual AttackService AttackService { get; } = new AttackService('Q');


        public WhiteQueen(int x, int y)
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



            if (XPosition == move.XMove)
            {
                if (CanMovesInCollumns(move, board))
                    return true;

            }


            if (YPosition == move.YMove)
            {
                if (CanMovesInRows(move, board))
                    return true;

            }


            if (!(Math.Abs(XPosition - move.XMove) == Math.Abs(YPosition - move.YMove)))
                return false;


            if (move.XMove < XPosition && move.YMove > YPosition)
            {
                int x = XPosition - 1;
                int y = YPosition + 1;

                do
                {
                    if (board[x, y] != ' ' && !AttackService.CanAttack(move, board))
                        return false;


                    x--;
                    y++;

                } while (x > move.XMove && y < move.YMove);

                return true;
            }


            if (move.XMove > XPosition && move.YMove > YPosition)
            {
                int x = XPosition + 1;
                int y = YPosition + 1;

                do
                {
                    if (board[x, y] != ' ' && !AttackService.CanAttack(move, board))
                        return false;


                    x++;
                    y++;

                } while (x < move.XMove && y < move.YMove);

                return true;

            }


            if (move.XMove < XPosition && move.YMove < YPosition)
            {
                int x = XPosition - 1;
                int y = YPosition - 1;

                do
                {
                    if (board[x, y] != ' ' && !AttackService.CanAttack(move, board))
                        return false;


                    x--;
                    y--;

                } while (x > move.XMove && y > move.YMove);
                return true;
            }


            if (move.XMove > XPosition && move.YMove < YPosition)
            {
                int x = XPosition + 1;
                int y = YPosition - 1;

                do
                {
                    if (board[x, y] != ' ' && !AttackService.CanAttack(move, board))
                        return false;


                    x++;
                    y--;

                } while (x < move.XMove && y > move.YMove);

                return true;
            }


            return false;
        }
    }
}
