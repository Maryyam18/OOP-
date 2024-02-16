using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.BIL
{
    internal class PlayerClass
    {
        public char PlayerSymbol;
        public int playerX;
        public int playerY;

        public PlayerClass(char playerSymbol, int x, int y)
        {
            PlayerSymbol = playerSymbol;
            playerX = x;
            playerY = y;
        }
    }

}
