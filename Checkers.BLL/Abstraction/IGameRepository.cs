using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Checkers.BLL.Models;

namespace Checkers.BLL.Abstraction
{
    public interface IGameRepository
    {
        Task CreateBoardAsync(Board board);

        Task<Board> GetBoardAsync(Guid id);

        Task<List<Board>> GetBoardsAsync();

        Task AddFiguresAsync(List<Figure> figures, Guid boardId);
    }
}
