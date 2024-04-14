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
    public class CastlingServiceTests
    {
        [Fact]
        public void CastlingService_ForInValidCastle_ReturnsFalse()   
        {
            //init
            var board = Board.InitGrid();   


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';

            board[7, 4] = ' ';
            board[6, 4] = 'q';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }


        [Fact]
        public void CastlingService_ForValidCastle_ReturnsTrue()    
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';
     
            board[6, 4] = 'q';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }



        [Theory]
        [InlineData(5, 3)]
        [InlineData(4, 2)]
        [InlineData(1, 4)]
        [InlineData(1, 8)]
        [InlineData(6, 5)]

        public void CastlingService_ForValidCastle_ReturnsTrue2(int x, int y)
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';

            board[x, y] = 'q';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }


    }
}
