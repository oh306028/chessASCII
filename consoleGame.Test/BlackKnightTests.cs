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
    public class BlackKnightTests
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
        public void BlackKnight_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'n';

            board[7, 2] = ' ';
            board[7, 4] = ' ';

            var pawn = new BlackKnight(5, 3);
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
        public void BlackKnight_ForAttackValidMoves_ReturnsTrue(int x, int y)
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'n';

            board[7, 2] = 'P';
            board[7, 4] = 'P';
            board[4, 1] = 'P';
            board[3, 2] = 'P';
            board[6, 1] = 'P';
            board[4, 5] = 'P';
            board[6, 5] = 'P';
            board[3, 4] = 'P';


            var pawn = new BlackKnight(5, 3);
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
        public void BlackKnight_ForInValidMoves_ReturnsFalse(int x, int y)
        {
            //init  

            var board = Board.InitGrid();
            board[5, 3] = 'n';


            var pawn = new BlackKnight(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);

        }
    }
}
