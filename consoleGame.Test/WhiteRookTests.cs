using consoleGame.Pieces;
using consoleGame.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Test
{
    public class WhiteRookTests
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 4)]
        [InlineData(4, 3)]
        [InlineData(6, 3)]
        public void WhiteRook_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'R';
            var pawn = new WhiteRook(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);

        }



        [Theory]
        [InlineData(5, 3)]
        [InlineData(4, 1)]
        [InlineData(3, 2)]
        [InlineData(1, 4)]

        public void WhiteRook_ForInvalidValidMoves_ReturnsFalse(int x, int y)   
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'R';
            var pawn = new WhiteRook(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);

        }



        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1)]
        [InlineData(3, 3)]
        [InlineData(7, 3)]

        public void WhiteRook_ForAttackInvalidMoves_ReturnsFalse(int x, int y)  
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'R';

            board[5, 4] = 'P';
            board[5, 2] = 'P';
            board[4, 3] = 'P';
            board[6, 3] = 'P';

            var pawn = new WhiteRook(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);

        }




        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1)]
        [InlineData(3, 3)]


        public void WhiteRook_ForAttackvalidMoves_ReturnsTrue(int x, int y) 
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'R';

            board[5, 5] = 'p';
            board[5, 1] = 'p';
            board[3, 3] = 'p';
          
            var pawn = new WhiteRook(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);

        }


        [Theory]
        [InlineData(3, 2)]
        [InlineData(2, 4)]
        [InlineData(6, 1)]
        [InlineData(5, 3)]
        [InlineData(7, 5)]
        [InlineData(7, 2)]

        public void WhiteRook_ForInValidMoves_ReturnFalse2(int x, int y)
        {
            //init
                
            var board = Board.InitGrid();
            board[5, 3] = 'R';

            board[2, 4] = ' ';
            board[7, 5] = ' ';
            board[7, 2] = ' ';


            var pawn = new WhiteRook(5, 3); 
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }


        [Theory]
        [InlineData(3, 3)]
        [InlineData(5, 1)]


        public void WhiteRook_ForInValidAttackMoves_ReturnFalse(int x, int y)   
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'R';


            board[3, 3] = 'p';
            board[5, 1] = 'p';
            board[5, 2] = 'p';
            board[4, 3] = 'p';



            var pawn = new WhiteQueen(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }

    }
}
