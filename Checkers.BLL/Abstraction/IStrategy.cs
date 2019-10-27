using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Checkers.BLL.Abstraction
{
    public interface IStrategy
    {
        Point Go(Point oldPosition, Point newPosition);
    }
}
