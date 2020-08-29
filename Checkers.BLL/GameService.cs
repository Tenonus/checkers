using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Checkers.BLL.Abstraction;
using Checkers.BLL.Models;

namespace Checkers.BLL
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public void RenderBoard(List<Figure> board)
        {
            var isBlack = false;
            for (int y = 7; y >= 0; y--)
            {
                Console.Write($"{y + 1} |");
                for (int x = 0; x <= 7; x++)
                {
                    if (!isBlack) Console.BackgroundColor = ConsoleColor.White;
                    isBlack = !isBlack;
                    var figure = board.FirstOrDefault(a => a.Position.X == x && a.Position.Y == y);
                    if (figure != null)
                    {
                        if (figure.Color == FigureColor.Black) Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                        Console.ResetColor();

                }

                isBlack = !isBlack;
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
                result.Add(new Figure(new Point(x, y), FigureColor.White));
            }

            y = 1;
            x = 1;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y), FigureColor.White));
            }

            y = 2;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y), FigureColor.White));
            }

            y = 5;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y), FigureColor.Black));
            }

            y = 6;
            x = 1;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y), FigureColor.Black));
            }

            y = 7;
            x = 0;
            for (; x < 8; x += 2)
            {
                result.Add(new Figure(new Point(x, y), FigureColor.Black));
            }

            return result;
        }

        public async Task<Board> GetBoardAsync(Guid boardId)
        {
            var result = await _repository.GetBoardAsync(boardId);
            return result;
        }
    }
}
