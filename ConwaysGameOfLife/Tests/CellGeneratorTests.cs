using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class CellGeneratorTests
    {
        private CellGenerator _generator;

        [SetUp]
        public void SetUp()
        {
            _generator = new CellGenerator();
        }


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

        /*[Test]
        public void GenerateCells_AskForTenCells_OrderShouldntMatch()
        {
            var cells1 = _generator.GenerateCells(10);
            var cells2 = _generator.GenerateCells(10);

            //TODO come back - make this pass


        }*/
    }
}