using System;
using System.Collections.Generic;
using System.Diagnostics;
using Moq;
using NUnit.Framework;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class GameOfLifeBoardTests
    {
        [Test]
        public void Ctor_GivenDimensions_CorrectDisplay()
        {
            var board = new GameOfLifeBoard(10,10);
            var renderer = new GameBoardRenderer();
            var output = renderer.Render(board);

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }


        [Test]
        public void Ctor_GivenDimensions_IsNotNull()
        {
            var board = new GameOfLifeBoard(30,30);

            Assert.That(board, Is.Not.Null);
            Assert.That(board.Width, Is.EqualTo(30));
            Assert.That(board.Height, Is.EqualTo(30));
        }

        [Test]
        public void Ctor_GivenDimensions_RowsAreNotNull()
        {
            var board = new GameOfLifeBoard(30,30);

            Assert.That(board.Rows, Is.Not.Null);
            Assert.That(board.Rows.Count, Is.EqualTo(30));
            Assert.That(board.Rows[0].Count, Is.EqualTo(30));
        }

        [Test]
        public void Ctor_GivenDimensions_CellsPopulated()
        {
            var board = new GameOfLifeBoard(1,1);
            Assert.That(board.Rows[0][0], Is.TypeOf<Cell>());

        }

        [Test]
        public void Ctor_GivenDimensionsAndStrategy_GenerateCellsUsingSuppliedStrategy()
        {
            var expectedCell = new Cell();
            var mockStrategy = new Mock<ICellGenerationStrategy>();
            mockStrategy.Setup(x => x.GenerateCells(It.IsAny<int>())).Returns(new List<Cell> {expectedCell});

            var board = new GameOfLifeBoard(1, 1, mockStrategy.Object);
            Assert.That(board.Rows[0][0], Is.EqualTo(expectedCell));
        }

    }

}