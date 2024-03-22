using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class GridManager
    {
        private readonly char[,] _board;
        private readonly IPiece _piece;
        private readonly MoveService _moveService;

        public GridManager(char[,] board, IPiece piece, MoveService moveService)
        {
           _board = board;
          _piece = piece;
            _moveService = moveService;
        }
    
        

        public bool CanRewriteBoard()
        {
            if (_piece.CanMove(_moveService, _board))
                return true;

            return false;
        }



        public void RewriteBoard()
        {
            if (CanRewriteBoard())
            {
                _board[_piece.XPosition, _piece.YPosition] = ' ';
                _board[_moveService.XMove, _moveService.YMove] = _piece.Symbol;
                
            }
        }



    }       
}
