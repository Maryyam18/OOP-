using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_game_task
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

        public void movePlayerUp(char[,] maze, ref int playerX, ref int playerY, char PlayerSymbol)
        {
            if (maze[playerX - 1, playerY] == ' ' || maze[playerX - 1, playerY] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX - 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(PlayerSymbol);
            }
        }

        public void movePlayerDown(char[,] maze, ref int playerX, ref int playerY, char PlayerSymbol)
        {
            if (maze[playerX + 1, playerY] == ' ' || maze[playerX + 1, playerY] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX + 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(PlayerSymbol);
            }
        }
        public void movePlayerLeft(char[,] maze, ref int playerX, ref int playerY, char PlayerSymbol)
        {
            if (maze[playerX, playerY - 1] == ' ' || maze[playerX, playerY - 1] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY - 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(PlayerSymbol);
            }
        }
        public void movePlayerRight(char[,] maze, ref int playerX, ref int playerY, char PlayerSymbol)
        {
            if (maze[playerX, playerY + 1] == ' ' || maze[playerX, playerY + 1] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY + 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(PlayerSymbol);
            }
        }

    }

}
