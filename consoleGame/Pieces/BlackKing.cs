using consoleGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Pieces
{
    public class BlackKing : WhiteKing
    {
        public BlackKing(int x, int y) : base(x, y)
        {

        }
        public new char Symbol { get; set; } = 'k';
        public override AttackService AttackService { get; } = new AttackService('k');


    }
}
