using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Checkers.BLL.Abstraction;
using Checkers.BLL.Models;

namespace Checkers.BLL.Impl
{
    public class CheckerCommand : ICommand
    {
        private readonly Figure _figure;
        private readonly Point _newPosition;
        private List<Figure> _figures;

        public CheckerCommand(Figure figure, List<Figure> figures, Point newPosition)
        {
            _figure = figure;
            _figures = figures;
            _newPosition = newPosition;
        }

        private bool CheckMoveForCorrect(Point oldPosition, Point newPosition)
        {
            var isOnTheBoard = newPosition.X >= 0 && newPosition.Y >= 0
                                                  && newPosition.X < 8 && newPosition.Y < 8;
            var isEmptySpace = newPosition.X == oldPosition.X + 1
                               || newPosition.X == oldPosition.X - 1;
            var isMoveToTop = newPosition.Y == oldPosition.Y + 1;
            var isFreeMove = CheckMoveForFree();
            return isOnTheBoard && isMoveToTop && isEmptySpace && isFreeMove;
        }

        private bool CheckMoveForFree()
        {
            return !_figures.Any(a => a.Position == _newPosition && a.Id == _figure.Id);
        }

        public Point Move()
        {
            var isCorrectMove = CheckMoveForCorrect(_figure.Position, _newPosition);
            var result = isCorrectMove ? _newPosition : _figure.Position;
            _figure.Position = result;
            return result;
        }
    }
}
