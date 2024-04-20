using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class BlackKing : WhiteKing
    {
        public BlackKing(int x, int y) : base(x, y)
        {

        }
        public new char Symbol { get; set; } = 'k';

        public override AttackService AttackService { get; } = new AttackService('k');

        public override bool CanMove(MoveService move, char[,] board)
        {

            if (move.XMove == XPosition && move.YMove == YPosition)
                return false;


            if (board[move.XMove, move.YMove] != ' ' && !AttackService.CanAttack(move, board))
                return false;


            if (XPosition == move.XMove && (YPosition + 1 == move.YMove || YPosition - 1 == move.YMove))
            {
                if (ValidMove(move, board)) { HasMoved = true; return true; }
            }


            if (YPosition == move.YMove && (XPosition + 1 == move.XMove || XPosition - 1 == move.XMove))
            {
                if (ValidMove(move, board)) { HasMoved = true; return true; }
            }


            if (Math.Abs(XPosition - move.XMove) == 1 && Math.Abs(YPosition - move.YMove) == 1)
            {
                if (ValidMove(move, board)) { HasMoved = true; return true; }
            }




            if (board[move.XMove, move.YMove + 1] == 'r')
            {
               
                //castling

                var castler = new CastlingService(new BlackKing(XPosition, YPosition), new BlackRook(move.XMove, move.YMove + 1), 'k');

                castler.GetDestinationIndex(YPosition, move.YMove);

                if (castler.CanCastle(board))
                { HasMoved = true; return true; }

            }


            if (board[move.XMove, move.YMove - 1] == 'r')
            {

                //castling

                var castler = new CastlingService(new BlackKing(XPosition, YPosition), new BlackRook(move.XMove, move.YMove - 1), 'k');

                castler.GetDestinationIndex(YPosition, move.YMove);

                if (castler.CanCastle(board))
                { HasMoved = true; return true; }

            }

            return false;
        }


    }
}
