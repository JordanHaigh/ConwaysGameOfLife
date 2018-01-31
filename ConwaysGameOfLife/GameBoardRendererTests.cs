using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class GameBoardRendererTests
    {
        private GameBoardRenderer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new GameBoardRenderer();
        }

        [Test]
        public void Render_GivenNullGameBoard_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => _renderer.Render(null));
            Assert.That(ex.Message, Is.EqualTo("Gameboard cannot be rendered."));
        }

        [Test]
        public void Render_GivenValidNotNullGameboard_ReturnsLinesOfCorrectWidth()
        {
            var gameOfLifeBoard = new GameOfLifeBoard(8,5);
            var output = _renderer.Render(gameOfLifeBoard);
            Assert.That(output.First().Count, Is.EqualTo(8));
        }

        [Test]
        public void Render_GivenValidNotNullGameboardWithZeroDimensions_ReturnsEmptyList()
        {
            var gameOfLifeBoard = new GameOfLifeBoard(0, 0);
            var output = _renderer.Render(gameOfLifeBoard);
            Assert.That(!output.Any());
        }

        [Test]
        public void Render_GivenDeadCell_OutputsDot()
        {
            var gameOfLifeBoard = new GameOfLifeBoard(1, 1);
            var output = _renderer.Render(gameOfLifeBoard);
            Assert.That(output.First(), Is.EqualTo("-"));
        }

        [Test]
        public void Render_EmptyBoardReasonableSize_LooksFine()
        {
            var gameOfLifeBoard = new GameOfLifeBoard(20, 20);
            var output = _renderer.Render(gameOfLifeBoard);

            foreach (var line in output)
            {
                Debug.WriteLine(line);   
            }
        }
    }
}