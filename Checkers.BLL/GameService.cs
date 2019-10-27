using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Checkers.BLL.Abstraction;
using Checkers.BLL.Models;

namespace Checkers.BLL
{
    public class GameService : IGameService
    {
        public void RenderBoard(List<Figure> board)
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write($"{y + 1} |");
                for (int x = 0; x <= 7; x++)
                {
                    Console.Write(board.Any(a => a.Position.X == x && a.Position.Y == y)
                        ? "X" : " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("-----------");
            Console.Write("   ");
            for (int x = 0; x <= 7; x++)
                Console.Write($"{x + 1}");
            Console.WriteLine();
            Console.WriteLine("===========");
        }

        public List<Figure> CreateBoard()
        {
            var result = new List<Figure>();
            int y = 0;
            int x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            y = 1;
            x = 1;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            y = 2;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            y = 5;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            y = 6;
            x = 1;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            y = 7;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y)));
            }

            return result;
        }
    }
}
