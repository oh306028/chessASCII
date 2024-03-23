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
    public class WhitePawnTests
    {
        [Theory]
        [InlineData(6, 1)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]
        [InlineData(7, 2)]
        [InlineData(7, 5)]
        public void WhitePawn_ForNotValidMoves_AreNotValidated(int x, int y)   
        {
            //init

            var board = Board.InitGrid();
            var pawn = new WhitePawn(7, 2);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);


        }   

        [Theory]
        [InlineData(6, 2)]
        [InlineData(5, 2)]
        public void WhitePawn_ForValidMoves_AreValidated(int x, int y)  
        {
            //init

            var board = Board.InitGrid();
            var pawn = new WhitePawn(7, 2);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);


        }

        [Fact]
        public void WhitePawn_ForValidAttackMoves_ReturnsValidated()        
        {
            //init

            var board = Board.InitGrid();
            var pawn = new WhitePawn(7, 2);
            var move = new MoveService(5, 2);
            var gridMan = new GridManager(board, pawn, move);

            board[5, 2] = 'p';

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);


        }

        [Fact]
        public void WhitePawn_ForInValidAttackMoves_ReturnsNotValidated()   
        {
            //init

            var board = Board.InitGrid();
            var pawn = new WhitePawn(7, 2);
            var move = new MoveService(5, 2);
            var gridMan = new GridManager(board, pawn, move);

            board[6, 2] = 'p';

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);


        }


    }
}
