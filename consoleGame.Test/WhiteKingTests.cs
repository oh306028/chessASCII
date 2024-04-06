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
    public class WhiteKingTests
    {

        [Theory]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 2)]
        [InlineData(5, 4)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]

        public void WhiteKing_ForValidMoves_ReturnTrue(int x, int y)    
        {
            //init
            var board = Board.InitGrid();

            board[5, 3] = 'K';



            var pawn = new WhiteKing(5, 3); 
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
        [InlineData(3, 4)]
        [InlineData(3, 2)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(4, 5)]
        [InlineData(5, 5)]
        [InlineData(6, 5)]
        [InlineData(7, 2)]
        [InlineData(7, 3)]
        [InlineData(7, 4)]

        public void WhiteKing_ForInValidMoves_ReturnTrue(int x, int y)
        {
            //init
            var board = Board.InitGrid();

            board[5, 3] = 'K';



            var pawn = new WhiteKing(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }

    }
}
