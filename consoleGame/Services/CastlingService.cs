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

        public CastlingService(ICastlingPiece king, ICastlingPiece rook)
        {
            _king = king;
            _rook = rook;
        }


        public bool CanCastle()
        {
            if (_king.HasMoved || _rook.HasMoved)
                return false;


            // some service to check if at the road between rook and king noone is attacking
            // should be the checkService to peek at the road fields

            // then can castle


            return true;
        }
    }
}
