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

        [Fact]
        public void CastlingService_ForValidrightCastle_ReturnsTrue()   
        {
            //init
            var board = Board.InitGrid();


            board[8, 6] = ' ';
            board[8, 7] = ' ';

            board[6, 4] = 'q';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 7);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }

        [Fact]
        public void CastlingService_ForValidrighWhitetCastle_ReturnsTrue()  
        {
            //init
            var board = Board.InitGrid();


            board[1, 6] = ' ';
            board[1, 7] = ' ';


            var pawn = new BlackKing(1, 5); 
            var move = new MoveService(1, 7);
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



        [Theory]
        [InlineData(5, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 6)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]
        [InlineData(6, 5)]
        [InlineData(4, 7)]

        public void CastlingService_ForInValidCastle_ReturnsFalse2(int x, int y)
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';
            board[7, 3] = ' ';
            board[7, 2] = ' ';
            board[7, 4] = ' ';

            board[x, y] = 'q';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }



        [Fact]
        public void CastlingService_ForInValidCastle_ReturnsFalse3()
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';


            board[6, 2] = 'n';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }



        [Fact]
        public void CastlingService_ForInValidCastle_ReturnsFalse4()
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';

            board[7, 2] = 'p';



            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }




        [Theory]
        [InlineData(5, 1)]
        [InlineData(5, 6)]
        [InlineData(5, 5)]

        public void CastlingService_ForInValidCastle_ReturnsFalse5(int x, int y)
        {
            //init
            var board = Board.InitGrid();


            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';

            board[7, 3] = ' ';
            board[7, 2] = ' ';
            board[7, 4] = ' ';


            board[x, y] = 'b';


            var pawn = new WhiteKing(8, 5);
            var move = new MoveService(8, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }



        [Theory]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(5, 4)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]

        public void CastlingService_ForBlackInValidCastle_ReturnsFalse(int x, int y)    
        {
            //init
            var board = Board.InitGrid();


            board[1, 3] = ' ';
            board[1, 2] = ' ';
            board[1, 4] = ' ';

            board[2, 3] = ' ';
            board[2, 2] = ' ';
            board[2, 4] = ' ';


            board[x, y] = 'Q';


            var pawn = new BlackKing(1, 5);
            var move = new MoveService(1, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }




        [Theory]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(5, 4)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]

        public void CastlingService_ForBlackValidCastle_ReturnsTrue(int x, int y) 
        {   
            //init
            var board = Board.InitGrid();


            board[1, 3] = ' ';
            board[1, 2] = ' ';
            board[1, 4] = ' ';



            board[x, y] = 'Q';


            var pawn = new BlackKing(1, 5);
            var move = new MoveService(1, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(true);
        }

        [Fact]
        public void CastlingService_ForBlackInValidCastle_ReturnsFalse2()       
        {
            //init
            var board = Board.InitGrid();


            board[1, 3] = ' ';
            board[1, 2] = ' ';
            board[1, 4] = ' ';

            board[2, 2] = 'P';



            var pawn = new BlackKing(1, 5);
            var move = new MoveService(1, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }


        [Theory]
        [InlineData(4, 1)]
        [InlineData(5, 6)]

        public void CastlingService_ForBlackInValidCastle_ReturnsFalse5(int x, int y)   
        {
            //init
            var board = Board.InitGrid();


            board[1, 3] = ' ';
            board[1, 2] = ' ';
            board[1, 4] = ' ';

            board[2, 3] = ' ';
            board[2, 2] = ' ';
            board[2, 4] = ' ';


            board[x, y] = 'B';


            var pawn = new BlackKing(1, 5);
            var move = new MoveService(1, 2);
            var gridMan = new GridManager(board, pawn, move);

            //act

            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }


    }
}
