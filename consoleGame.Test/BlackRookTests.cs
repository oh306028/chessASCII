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

    public class BlackRookTests
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 4)]
        [InlineData(4, 3)]
        [InlineData(6, 3)]
        public void BlackRook_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'r';
            var pawn = new BlackRook(5, 3);
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

        public void BlackRook_ForInvalidValidMoves_ReturnsFalse(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'r';
            var pawn = new BlackRook(5, 3);
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

        public void BlackRook_ForAttackInvalidMoves_ReturnsFalse(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'r';

            board[5, 4] = 'p';
            board[5, 2] = 'p';
            board[4, 3] = 'p';
            board[6, 3] = 'p';

            var pawn = new BlackRook(5, 3);
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


        public void BlackRook_ForAttackvalidMoves_ReturnsTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'r';

            board[5, 5] = 'P';
            board[5, 1] = 'P';
            board[3, 3] = 'P';

            var pawn = new BlackRook(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);

        }

    }
}
