using System;
using System.Collections.Generic;
using Checkers.BLL.Abstraction;

namespace Checkers.BLL.Models
{
    public class Board
    {
        public List<Figure> Figures { get; set; } = new List<Figure>();
        public Guid Id { get; set; } = new Guid();

        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Move(ICommand command)
        {
            command.Move();
        }
    }
}
