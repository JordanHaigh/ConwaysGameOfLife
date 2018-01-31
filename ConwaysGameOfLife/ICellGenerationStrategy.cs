using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public interface ICellGenerationStrategy
    {
        List<Cell> GenerateCells(int numberOfCellsToGenerate);

    }

    public class StaticListStrategy : ICellGenerationStrategy
    {
        private IEnumerable<Cell> _cells;

        public StaticListStrategy(IEnumerable<Cell> cells)
        {
            _cells = cells;
        }

        public List<Cell> GenerateCells(int numberOfCellsToGenerate)
        {
            return _cells.ToList();
        }
    }
}