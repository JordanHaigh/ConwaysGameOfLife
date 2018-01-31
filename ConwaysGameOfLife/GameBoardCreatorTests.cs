using NUnit.Framework;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class GameBoardCreatorTests
    {
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
    }
}