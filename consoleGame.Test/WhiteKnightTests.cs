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
    public class WhiteKnightTests
    {
        [Theory]
        [InlineData(3, 2)]
        [InlineData(4, 1)]
        [InlineData(3, 4)]
        [InlineData(6, 1)]
        [InlineData(6, 5)]
        [InlineData(7, 2)]
        [InlineData(7, 4)]
        [InlineData(4, 5)]
        public void WhiteKnight_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'N';

            board[7, 2] = ' ';
            board[7, 4] = ' ';

            var pawn = new WhiteKnight(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);

        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(4, 1)]
        [InlineData(3, 4)]
        [InlineData(6, 1)]
        [InlineData(6, 5)]
        [InlineData(7, 2)]
        [InlineData(7, 4)]
        [InlineData(4, 5)]
        public void WhiteKnight_ForAttackValidMoves_ReturnsTrue(int x, int y)
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'N';

            board[7, 2] = 'p';
            board[7, 4] = 'p';
            board[4, 1] = 'p';
            board[3, 2] = 'p';
            board[6, 1] = 'p';
            board[4, 5] = 'p';
            board[6, 5] = 'p';
            board[3, 4] = 'p';


            var pawn = new WhiteKnight(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);

        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(8, 8)]
        [InlineData(5, 3)]
        [InlineData(5, 2)]
        [InlineData(5, 1)]
        [InlineData(3, 3)]
        [InlineData(7, 3)]
        [InlineData(5, 5)]
        public void WhiteKnight_ForInValidMoves_ReturnsFalse(int x, int y)  
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'N';


            var pawn = new WhiteKnight(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);

        }
    }
}
