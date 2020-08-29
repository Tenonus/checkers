using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Checkers.BLL.Impl;
using Checkers.BLL.Models;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CheckerCommandTests
    {
        [Fact]
        public async Task Move_ToTopFreePlace_ShouldMakeMove()
        {
            // Arrange
            var board = new Board {Figures = new List<Figure>{new Figure()}};
            var position = new Point(1, 1);
            var command = new CheckerCommand(board.Figures.First(), board.Figures, position);

            // Act
            command.Move();

            // Assert
            board.Figures.First().Position.Should().Be(position);
        }

        [Fact]
        public async Task Move_ToBottomFreePlace_ShouldStayInPlace()
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position = new Point(1, 1);
            var newPosition = new Point(0, 0);
            var board = new Board { Figures = new List<Figure>() };
            board.Figures.Add(figure);
            var command = new CheckerCommand(figure, board.Figures, newPosition);

            // Act
            command.Move();

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(2, 2)]
        public async Task Move_ToInaccessiblePlace_ShouldStayInPlace(int x, int y)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position;
            var newPosition = new Point(x, y);
            var board = new Board { Figures = new List<Figure>() };
            board.Figures.Add(figure);
            var command = new CheckerCommand(figure, board.Figures, newPosition);

            // Act
            command.Move();

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(0, 0, -1, 1)]
        [InlineData(0, 0, -1, -1)]
        [InlineData(7, 7, 8, 8)]
        public async Task Move_ToOutOfBoard_ShouldStayInPlace(int oldX, int oldY, int newX, int newY)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position = new Point(oldX, oldY);
            var newPosition = new Point(newX, newY);
            var board = new Board { Figures = new List<Figure>() };
            board.Figures.Add(figure);
            var command = new CheckerCommand(figure, board.Figures, newPosition);

            // Act
            command.Move();

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(1, 2)]
        [InlineData(-2, -2)]
        public async Task Move_ToMoreThanOneField_ShouldStayInPlace(int x, int y)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position;
            var newPosition = new Point(x, y);
            var board = new Board { Figures = new List<Figure>() };
            board.Figures.Add(figure);
            var command = new CheckerCommand(figure, board.Figures, newPosition);

            // Act
            command.Move();

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Fact]
        public async Task Move_ToBusyField_ShouldStayInPlace()
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position;
            var figure1 = new Figure {Position = new Point(1, 1)};

            var board = new Board { Figures = new List<Figure>() };
            board.Figures.Add(figure);
            board.Figures.Add(figure1);

            var newPosition = new Point(1, 1);
            var command = new CheckerCommand(figure, board.Figures, newPosition);

            // Act
            command.Move();

            // Assert
            figure.Position.Should().Be(oldPosition);
        }
    }
}
