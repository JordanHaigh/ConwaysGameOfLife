using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            Assert.That(board.Board, Is.Not.Null);
            //Assert.That(board.Board.Count, Is.EqualTo(30));
            //Assert.That(board.Board, Is.EqualTo(30));
        }

        [Test]
        public void Ctor_GivenDimensions_CellsPopulated()
        {
            var board = new GameOfLifeBoard(1,1);
            Assert.That(board.Board[0, 0], Is.TypeOf<Cell>());

        }

        [Test]
        public void Ctor_GivenDimensionsAndStrategy_GenerateCellsUsingSuppliedStrategy()
        {
            var expectedCell = new Cell();
            var mockStrategy = new Mock<ICellGenerationStrategy>();
            mockStrategy.Setup(x => x.GenerateCells(It.IsAny<int>())).Returns(new List<Cell> {expectedCell});

            var board = new GameOfLifeBoard(1, 1, mockStrategy.Object);
            Assert.That(board.Board[0, 0], Is.EqualTo(expectedCell));
        }

        [Test]
        public void Step_GivenOneLivingCell_Dies()
        {
            var board = new GameOfLifeBoard(1,1,
                new StaticListStrategy(new List<Cell>
                {
                    new Cell{IsAlive = true}
                }));

            board.Step();

            Assert.That(board.Board[0, 0].IsAlive, Is.False);
        }

        [Test]
        public void Step_GivenMoreThanThreeNeighbours_Dies()
        {
            /*
                 If cell has > 3 living neighbours, cell dies
                 If cell has 2-3 living neighbours, cell lives
             */
            var board = new GameOfLifeBoard(3, 3,
                new StaticListStrategy(new List<Cell>
                {
                    new Cell{IsAlive = true},
                    new Cell{IsAlive = true},
                    new Cell{IsAlive = true},

                    new Cell{IsAlive = true},
                    new Cell{IsAlive = true}, //This one should die if all alive
                    new Cell{IsAlive = true},

                    new Cell{IsAlive = true},
                    new Cell{IsAlive = true},
                    new Cell{IsAlive = true}

                }));

            board.Step();

            Assert.That(board.Board[1, 1].IsAlive, Is.False);
        }

        [Test]
        public void Step_GiveTwoLivingNeighbours_Lives()
        {
            /*
                 If cell has < 2 living neighbours, cell dies
                 If cell has 2-3 living neighbours, cell lives
             */
            var board = new GameOfLifeBoard(3, 1,
                new StaticListStrategy(new List<Cell>
                {
                    new Cell{IsAlive = true}, //Should die
                    new Cell{IsAlive = true}, //He should live
                    new Cell{IsAlive = true} //Should die
                }));

            board.Step();

            Assert.That(board.Board[1, 0].IsAlive, Is.True);
        }



    }

}