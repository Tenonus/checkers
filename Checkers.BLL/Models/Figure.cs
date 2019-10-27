using System;
using System.Drawing;
using Checkers.BLL.Abstraction;

namespace Checkers.BLL.Models
{
    public class Figure
    {
        public Guid Id { get; set; }

        public Point Position { get; set; }
        
        public Figure() : this(new Point(0, 0))
        {
        }

        public Figure(Point position)
        {
            Position = position;
        }

        private IStrategy _strategy = new CheckerStrategy();

        public void ChangeStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Move(Point newPosition)
        {
            Position = _strategy.Go(Position, newPosition);
        }
    }
}
