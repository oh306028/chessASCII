using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class WhiteBishop : IPiece
    {
        public char Symbol { get; set; } = 'B';
        public int XPosition { get; set ; }
        public int YPosition { get; set ; }

        public AttackService AttackService { get; } = new AttackService('B');

        public WhiteBishop(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }


        public bool CanMove(MoveService move, char[,] board)
        {

            if (!(Math.Abs(XPosition - move.XMove) == Math.Abs(YPosition - move.YMove)))
                return false;


            if (board[move.XMove, move.YMove] != ' ')
            {
                if (!AttackService.CanAttack(move, board))
                    return false;
            }


            if(move.XMove < XPosition && move.YMove > YPosition)
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
            }



            return true;
        }
    }
}
