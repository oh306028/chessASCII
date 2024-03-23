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
    public class WhiteBishopTests
    {
        [Theory]
        [InlineData(3, 1)]
        [InlineData(3, 5)]
        [InlineData(6, 4)]
        [InlineData(6, 2)]
        public void WhiteBishop_ForValidMoves_ReturnTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'B';
            var pawn = new WhiteBishop(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }



        [Theory]
        [InlineData(5, 4)]
        [InlineData(5, 2)]
        [InlineData(4, 3)]
        [InlineData(6, 3)]
        public void WhiteBishop_ForInValidMoves_ReturnFalse(int x, int y)   
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'B';
            var pawn = new WhiteBishop(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }


        [Theory]
        [InlineData(3, 1)]
        [InlineData(3, 5)]

        public void WhiteBishop_ForAttackInValidMoves_ReturnFalse(int x, int y)     
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'B';

            board[4, 2] = 'P';
            board[4, 4] = 'P';

            var pawn = new WhiteBishop(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }



        [Theory]
        [InlineData(3, 1)]
        [InlineData(3, 5)]
        [InlineData(6, 2)]
        [InlineData(6, 4)]
        public void WhiteBishop_ForAttackValidMoves_ReturnTrue(int x, int y)    
        {
            //init

            var board = Board.InitGrid();

            board[5, 3] = 'B';

            board[3, 1] = 'p';
            board[3, 5] = 'p';
            board[6, 2] = 'p';
            board[6, 4] = 'p';

            var pawn = new WhiteBishop(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }




    }
}
