using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_game_task
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

        public void moveEnemy(char[,] maze, ref int enemyX, ref int enemyY, ref bool enemyMovingRight, char enemiesSymbol)
        {
            maze[enemyX, enemyY] = ' ';
            Console.SetCursorPosition(enemyY, enemyX);
            Console.Write(" ");

            if (enemyMovingRight)
            {
                if (maze[enemyX, enemyY + 1] == ' ')
                {
                    enemyY = enemyY + 1;
                }
                else
                {
                    enemyMovingRight = false;
                }
            }
            else
            {
                if (maze[enemyX, enemyY - 1] == ' ')
                {
                    enemyY = enemyY - 1;
                }
                else
                {
                    enemyMovingRight = true;
                }
            }

            Console.SetCursorPosition(enemyY, enemyX);
            Console.Write(enemiesSymbol);
        }
    }
}

