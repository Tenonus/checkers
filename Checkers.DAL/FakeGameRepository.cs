using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.BLL.Abstraction;
using Checkers.BLL.Models;

namespace Checkers.DAL
{
    public class FakeGameRepository : IGameRepository
    {
        private static readonly List<Board> _boards;

        static FakeGameRepository()
        {
            _boards = new List<Board>();
        }

        public async Task CreateBoardAsync(Board board)
        {
            _boards.Add(board);
        }

        public async Task<Board> GetBoardAsync(Guid id)
        {
            return _boards.SingleOrDefault(x => x.Id == id);
        }

        public async Task<List<Board>> GetBoardsAsync()
        {
            return _boards;
        }

        public async Task AddFiguresAsync(List<Figure> figures, Guid boardId)
        {
            var board = await GetBoardAsync(boardId);
            board.Figures.AddRange(figures);
        }
    }
}
