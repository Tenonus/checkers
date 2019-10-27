using System.Drawing;
using Checkers.BLL.Abstraction;

namespace Checkers.BLL
{
    public class CheckerStrategy : IStrategy
    {
        private bool CheckMoveForCorrect(Point oldPosition, Point newPosition)
        {
            var isOnTheBoard = newPosition.X >= 0 && newPosition.Y >= 0
                                                  && newPosition.X < 8 && newPosition.Y < 8;
            var isEmptySpace = newPosition.X == oldPosition.X + 1
                               || newPosition.X == oldPosition.X - 1;
            var isMoveToTop = newPosition.Y == oldPosition.Y + 1;
            return isOnTheBoard && isMoveToTop && isEmptySpace;
        }

        public Point Go(Point oldPosition, Point newPosition)
        {
            var isCorrectMove = CheckMoveForCorrect(oldPosition, newPosition);
            return isCorrectMove ? newPosition : oldPosition;
        }
    }
}
