using System;
using System.Drawing;
using Checkers.BLL.Abstraction;

namespace Checkers.BLL.Models
{
    public class Figure
    {
        public Guid Id { get; set; }

        public Point Position { get; set; }

        public FigureColor Color { get; set; }

        public FigureRank Rank { get; set; } = FigureRank.Checker;
        
        public Figure() : this(new Point(0, 0), FigureColor.White)
        {
        }

        public Figure(Point position, FigureColor color)
        {
            Position = position;
            Color = color;
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
