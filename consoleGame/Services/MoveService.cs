using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGame.Services
{
    public class MoveService
    {
        public int XMove { get; set; }
        public int YMove { get; set; }  
        public MoveService(int xMove, int yMove)
        {
            XMove = xMove;
            YMove = yMove;
        }
    }
}
