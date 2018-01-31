using System.Linq;
using NUnit.Framework;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class CellGeneratorTests
    {
        [Test]
        public void GenerateCells_AskForTwoCells_OneAliveOneDead()
        {
            var generator = new CellGenerator();
            var cells = generator.GenerateCells(2);
            Assert.That(cells.Count(x => x.IsAlive), Is.EqualTo(1));
            Assert.That(cells.Count(x => !x.IsAlive), Is.EqualTo(1));

        }

        [Test]
        public void GenerateCells_AskForThreeCells_OneDeadTwoAliveReturned()
        {
            var generator = new CellGenerator();
            var cells = generator.GenerateCells(3);
            Assert.That(cells.Count(x => x.IsAlive), Is.EqualTo(1));
            Assert.That(cells.Count(x => !x.IsAlive), Is.EqualTo(2));

        }
    }
}