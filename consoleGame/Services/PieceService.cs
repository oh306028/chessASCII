using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class PieceService
    {

        public PieceService()
        {
            BoardGrid = Board.InitGrid();
        }

        public readonly char[,] BoardGrid;
   
        public IPiece piece { get; set; }

        public AttackService AttackService { get; set; }
     
        public bool ValidMoveOnGrid()
        {

            if(piece.CanMove(BoardGrid) || AttackService.CanAttack())
                return true;
            

            return false;
        }



    }
}
