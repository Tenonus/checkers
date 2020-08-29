using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Checkers.BLL.Models;
using Checkers.DAL;
using FluentAssertions;
using Xunit;

namespace Tests.DAL
{
    public class FakeGameRepositoryTests
    {
        [Fact]
        public async Task AddFigures_WithThreeFigures_ShouldReturnBoardWithTheseFigures()
        {
            // Arrange
            var repository = new FakeGameRepository();
            var figures = new List<Figure>
            {
                new Figure(new Point(0, 0), FigureColor.White),
                new Figure(new Point(2, 0), FigureColor.White),
                new Figure(new Point(4, 0), FigureColor.White),
            };
            var board = new Board();
            await repository.CreateBoardAsync(board);

            // Act
            await repository.AddFiguresAsync(figures, board.Id);
            
            // Assert
            board.Figures.Count.Should().Be(figures.Count);
            board.Figures.Should().BeEquivalentTo(figures);
        }
    }
}
