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
    public class WhiteQueenTests
    {
        [Theory]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 4)]
        [InlineData(5, 1)]
        [InlineData(5, 4)]
        [InlineData(6, 2)]
        [InlineData(7, 3)]
        [InlineData(7, 5)]
        [InlineData(5, 7)]
        public void WhiteQueen_ForValidMoves_ReturnTrue(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'Q';

            board[7, 3] = ' ';
            board[7, 5] = ' ';

            var pawn = new WhiteQueen(5, 3);
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
        [InlineData(7, 2)]

        public void WhiteQueen_ForInValidMoves_ReturnFalse(int x, int y)
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'Q';
                
            board[2, 4] = ' ';
            board[7, 2] = ' ';


            var pawn = new WhiteQueen(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }



        [Theory]
        [InlineData(3, 3)]
        [InlineData(3, 5)]
        [InlineData(5, 1)]
        [InlineData(7, 3)]

        public void WhiteQueen_ForInValidMoves_ReturnFalse2(int x, int y)   
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'Q';


            board[4, 4] = 'P';
            board[4, 3] = 'P';
            board[5, 2] = 'P';
            board[6, 3] = 'p';
            board[7, 3] = 'p';


            var pawn = new WhiteQueen(5, 3);
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
        [InlineData(3, 3)]
        [InlineData(5, 1)]


        public void WhiteQueen_ForInValidAttackMoves_ReturnFalse(int x, int y)  
        {
            //init

            var board = Board.InitGrid();
            board[5, 3] = 'Q';


            board[3, 3] = 'p';
            board[5, 1] = 'p';
            board[5, 2] = 'p';
            board[4, 3] = 'p';
            board[4, 2] = 'p';
            board[4, 4] = 'p';



            var pawn = new WhiteQueen(5, 3);
            var move = new MoveService(x, y);
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }




        [Theory]
        [InlineData(8, 2)]
        [InlineData(8, 3)]
        [InlineData(8, 4)]
        public void BlackQueen_ForInValidAttackMoves_ReturnFalseSpecialTest(int x, int y)   
        {
            //init

            var board = Board.InitGrid();

            board[5, 3] = 'q';

            board[8, 3] = ' ';
            board[8, 2] = ' ';
            board[8, 4] = ' ';




            var pawn = new BlackQueen(5, 3);
            var move = new MoveService(x, y);   
            var gridMan = new GridManager(board, pawn, move);

            //act


            var result = gridMan.CanRewriteBoard();


            //assert

            result.Should().Be(false);
        }
    }
}

