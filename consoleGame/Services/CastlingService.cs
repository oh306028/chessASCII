using consoleGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class CastlingService
    {
        private readonly ICastlingPiece _king;
        private readonly ICastlingPiece _rook;
        private readonly char _symbol;

        private int StartIx;
        private int EndIx;  
        public CastlingService(ICastlingPiece king, ICastlingPiece rook, char symbol)
        {
            _king = king;
            _rook = rook;
            _symbol = symbol;
        }

        public void GetDestinationIndex(int startIx,int endIx)  
        {
            StartIx = startIx;
            EndIx = endIx;
        }   


        private List<int> GetRoad()
        {
            var road = new List<int>();

            if(EndIx > StartIx)
            {

                for (int i = EndIx; i > StartIx; i--)
                {
                    road.Add(i);
                }

            }
            else
            {
                for (int i = EndIx; i < StartIx; i++)
                {
                    road.Add(i);
                }

            }


            return road;
        }



        private bool IsAttackingTheCastlingRoadByBlack(char[,] board)
        {
            var checker = new CheckService(board);

            var roadFields = GetRoad();


            foreach(var field in roadFields)
            {
                if (checker.BlackCanCheck(8, field))
                    return true;
            }
             
            return false;
        }


        private bool IsAttackingTheCastlingRoadByWhite(char[,] board)
        {   
            var checker = new CheckService(board);

            var roadFields = GetRoad();

            foreach (var field in roadFields)
            {
                if (checker.WhiteCanCheck(1, field))
                    return true;
            }

            return false;
        }



        public bool CanCastle(char[,] board)
        {
            if (_king.HasMoved || _rook.HasMoved)
                return false;
         
            if(_symbol == 'K')
            {
                if (IsAttackingTheCastlingRoadByBlack(board))
                    return false;
            }
          
            if (_symbol == 'k')
            {
                if (IsAttackingTheCastlingRoadByWhite(board))
                    return false;
            }
               

            return true;
        }
    }
}
