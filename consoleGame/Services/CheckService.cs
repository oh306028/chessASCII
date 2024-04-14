using consoleGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class CheckService
    {

        private int xKingPos { get; set; }
        private int yKingPos { get; set; }
        private char[,] _board;
        private List<char> BlackPiecesList { get; } = new List<char>() { 'p', 'r', 'b', 'n', 'q', 'k' };
        private List<char> WhitePiecesList { get; } = new List<char>() { 'P', 'R', 'B', 'N', 'Q', 'K' };


        public CheckService(char[,] board)
        {
            _board = board;
          
        }



        private KeyValuePair<int, int> GetWhiteKingPosition()   
        {

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (_board[i, j] == 'K')
                    {
                        return new KeyValuePair<int, int>(i, j);

                    }

                }

            }
            return new KeyValuePair<int, int>(0, 0);

        }
        private KeyValuePair<int,int> GetBlackKingPosition()  
        {        
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (_board[i, j] == 'k')
                    {
                        return new KeyValuePair<int, int>(i,j);
                       
                    }

                }

            }
            return new KeyValuePair<int, int>(0,0);

        }
        private KeyValuePair<int, int> GetPiecePosition(char piece)  
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    if (_board[i, j] == piece)
                       return new KeyValuePair<int, int>(i, j);
                    
                }

            }
           
            return new KeyValuePair<int, int>(0, 0);
        }
        private IPiece GetCurrentPieceObject(char pieceChar, KeyValuePair<int,int> position)
        {

            if (BlackPiecesList.Contains(pieceChar))
            {
                switch (pieceChar)
                {
                    case 'p':
                        return new BlackPawn(position.Key, position.Value);
                    case 'r':
                        return new BlackRook(position.Key, position.Value);
                    case 'n':
                        return new BlackKnight(position.Key, position.Value);
                    case 'q':
                        return new BlackQueen(position.Key, position.Value);
                    case 'b':
                        return new BlackBishop(position.Key, position.Value);
                }
            }
            else
            {
                switch (pieceChar)
                {
                    case 'P':
                        return new BlackPawn(position.Key, position.Value);
                    case 'R':
                        return new BlackRook(position.Key, position.Value);
                    case 'N':
                        return new BlackKnight(position.Key, position.Value);
                    case 'Q':
                        return new BlackQueen(position.Key, position.Value);
                    case 'B':
                        return new BlackBishop(position.Key, position.Value);
                }
            }

            return new BlackKing(0, 0);
        }



        //for checks
        public bool WhiteCanCheck()
        {
            var kingPos = new KeyValuePair<int, int>();

            kingPos = GetBlackKingPosition();
            _board[kingPos.Key, kingPos.Value] = ' ';

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (WhitePiecesList.Contains(_board[i, j]))
                    {
                        var piece = GetCurrentPieceObject(_board[i, j], new KeyValuePair<int, int>(i, j));

                        var gridManager = new GridManager(_board, piece, new MoveService(kingPos.Key, kingPos.Value));

                        var result = gridManager.CanRewriteBoard();

                        if (result)
                        {
                            _board[kingPos.Key, kingPos.Value] = 'k';
                            return true;
                        }
                    }
                }

            }

            _board[kingPos.Key, kingPos.Value] = 'k';
            return false;
        }

        public bool BlackCanCheck()
        {
            var kingPos = new KeyValuePair<int, int>();

            kingPos = GetWhiteKingPosition();   
            _board[kingPos.Key, kingPos.Value] = ' ';

            for(int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (BlackPiecesList.Contains(_board[i, j]))
                    {                     
                        var piece = GetCurrentPieceObject(_board[i, j], new KeyValuePair<int, int>(i,j));

                        var gridManager = new GridManager(_board, piece, new MoveService(kingPos.Key, kingPos.Value));

                        var result = gridManager.CanRewriteBoard();

                        if (result)
                        {
                            _board[kingPos.Key, kingPos.Value] = 'K';
                            return true;
                        }
                    }
                }
               
            }  

            _board[kingPos.Key, kingPos.Value] = 'K';
            return false;

        }



        // for castling
        public bool WhiteCanCheck(int xMove, int yMove)
        {
      
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (WhitePiecesList.Contains(_board[i, j]))
                    {
                        var piece = GetCurrentPieceObject(_board[i, j], new KeyValuePair<int, int>(i, j));

                        var gridManager = new GridManager(_board, piece, new MoveService(xMove, yMove));

                        var result = gridManager.CanRewriteBoard();

                        if (result)      
                            return true;
                        
                    }
                }

            }        
            return false;
        }

        public bool BlackCanCheck(int xMove, int yMove)
        {
 
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    if (BlackPiecesList.Contains(_board[i, j]) && _board[i,j] != 'k')
                    {
                        var piece = GetCurrentPieceObject(_board[i, j], new KeyValuePair<int, int>(i, j));


                        if(piece.Symbol == 'r')                      
                            if (piece.YPosition != yMove)
                                continue;
                        

                        if (piece.Symbol == 'n')
                            if (piece.XPosition == 1)
                                continue;


                        if (_board[i, j] == 'p')
                            if (piece.XPosition != 7)
                                continue;


                        var gridManager = new GridManager(_board, piece, new MoveService(xMove, yMove));

                        var result = gridManager.CanRewriteBoard();


                        if (result)
                            return true;
                        
                    }
                }

            }
        
            return false;

        }

     
    }
}
