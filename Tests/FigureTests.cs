using System.Drawing;
using System.Threading.Tasks;
using Checkers.BLL.Models;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class FigureTests
    {
        [Fact]
        public async Task Go_WithMoveToTopFreePlace_ShouldMakeMove()
        {
            // Arrange
            var figure = new Figure();
            var position = new Point(1, 1);

            // Act
            figure.Move(position);

            // Assert
            figure.Position.Should().Be(position);
        }

        [Fact]
        public async Task Go_WithMoveToBottomFreePlace_ShouldStayInPlace()
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position = new Point(1, 1);
            var newPosition = new Point(0, 0);

            // Act
            figure.Move(newPosition);

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(2, 2)]
        public async Task Go_WithMoveToInaccessiblePlace_ShouldStayInPlace(int x, int y)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position;
            var newPosition = new Point(x, y);

            // Act
            figure.Move(newPosition);

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(0, 0, -1, 1)]
        [InlineData(0, 0, -1, -1)]
        [InlineData(7, 7, 8, 8)]
        public async Task Go_WithMoveToOutOfBoard_ShouldStayInPlace(int oldX, int oldY, int newX, int newY)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position = new Point(oldX, oldY);
            var newPosition = new Point(-1, 1);

            // Act
            figure.Move(newPosition);

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(1, 2)]
        [InlineData(-2, -2)]
        public async Task Go_WithMoveToMoreThanOneField_ShouldStayInPlace(int x, int y)
        {
            // Arrange
            var figure = new Figure();
            var oldPosition = figure.Position;
            var newPosition = new Point(x, y);

            // Act
            figure.Move(newPosition);

            // Assert
            figure.Position.Should().Be(oldPosition);
        }

        [Fact]
        public async Task Go_WithMoveToBusyField_ShouldStayInPlace()
        {
            // Arrange
            
        }
    }
}
