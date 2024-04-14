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
    public class CheckServiceTests
    {
        [Fact]
        public void CheckService_ForValidCheckBlackQueen_ReturnsTrue()  
        {
            //init

            var board = Board.InitGrid();


            board[7, 6] = ' ';
            board[5, 8] = 'q';

            var checkService = new CheckService(board);

            //act

            var result = checkService.BlackCanCheck();


            //assert    

            result.Should().Be(true);
        }

        [Fact]
        public void CheckService_ForValidCheckBlackRook_ReturnsTrue()
        {
            //init
                
            var board = Board.InitGrid();


            board[7, 5] = ' ';
            board[6, 5] = 'r';

            var checkService = new CheckService(board);

            //act

            var result = checkService.BlackCanCheck();  


            //assert    

            result.Should().Be(true);
        }

        [Fact]
        public void CheckService_ForValidCheckBlackKnight_ReturnsTrue()
        {
            //init

            var board = Board.InitGrid();


            board[7, 5] = ' ';
            board[6, 6] = 'n';

            var checkService = new CheckService(board);

            //act

            var result = checkService.BlackCanCheck();


            //assert

            result.Should().Be(true);
        }

        [Fact]
        public void CheckService_ForValidCheckWhiteRook_ReturnsTrue()
        {   
            //init

            var board = Board.InitGrid();


            board[2, 5] = ' ';
            board[6, 5] = 'R';

            var checkService = new CheckService(board);

            //act

            var result = checkService.WhiteCanCheck();


            //assert

            result.Should().Be(true);
        }
    }
}
