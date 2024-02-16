using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.BIL
{
    internal class EnemyClass
    {
        public char EnemySymbol;
        public int enemyX;
        public int enemyY;

        public EnemyClass(char enemySymbol, int x, int y)
        {
            EnemySymbol = enemySymbol;
            enemyX = x;
            enemyY = y;
        }
    }
}
