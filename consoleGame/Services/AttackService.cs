using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class AttackService
    {
        private char _symbol { get; set; }
        public AttackService(char symbol)
        {
            _symbol = symbol;
        }

        private List<char> BlackPiecesList { get; } = new List<char>() { 'p', 'r', 'b', 'n', 'q', 'k' };
        private List<char> WhitePiecesList { get; } = new List<char>() { 'P', 'R', 'B', 'N', 'Q', 'K' };



        public bool CanAttack(MoveService move, char[,] board)    
        {

            if (BlackPiecesList.Contains(_symbol))
                if (WhitePiecesList.Contains(board[move.XMove, move.YMove]))
                {
                    return true;
                }



            if (WhitePiecesList.Contains(_symbol))          
                if (BlackPiecesList.Contains(board[move.XMove, move.YMove]))
                {
                    return true;
                }

            

            return false;
        }

    }
}
