using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers.BLL.Models
{
    public class Board
    {
        public List<Figure> Figures { get; set; } = new List<Figure>();
        public Guid Id { get; set; } = new Guid();
    }
}
