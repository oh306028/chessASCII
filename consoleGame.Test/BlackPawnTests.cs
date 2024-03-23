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
    public class BlackPawnTests
    {
        [Theory]
        [InlineData(3, 2)]
        [InlineData(4, 2)]
        public void BlackPawn_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            var pawn = new BlackPawn(2, 2);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 1)]
        [InlineData(4, 2)]
        public void BlackPawn_ForInValidMoves_ReturnsFalse(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            var pawn = new BlackPawn(2, 2);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            board[3, 2] = 'p';

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }

        [Fact]
        public void BlackPawn_ForValidAttackMove_ReturnsTrue()
        {
            //init

            var board = Board.InitGrid();
            var pawn = new BlackPawn(2, 2);
            var move = new MoveService(4, 2);
            var gridMan = new GridManager(board, pawn, move);

            board[4, 2] = 'P';

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }

        [Fact]
        public void BlackPawn_ForValidAttackMove_ReturnsTrue2()
        {
            //init

            var board = Board.InitGrid();
            var pawn = new BlackPawn(2, 2);
            var move = new MoveService(3, 2);
            var gridMan = new GridManager(board, pawn, move);

            board[3, 2] = 'P';

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }


    }
}
