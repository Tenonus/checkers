using System;
using System.Collections.Generic;
using System.Text;
using Checkers.BLL.Models;

namespace Checkers.BLL.Abstraction
{
    public interface IGameService
    {
        void RenderBoard(List<Figure> board);
        List<Figure> CreateBoard();
    }
}
