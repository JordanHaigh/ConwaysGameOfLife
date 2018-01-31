using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class CellGenerator : ICellGenerationStrategy
    {
        public List<Cell> GenerateCells(int numberOfCellsToGenerate)
        {
            var half = numberOfCellsToGenerate / 2;

            var list = new List<Cell>();
            list.AddRange(Enumerable.Repeat(new Cell { IsAlive = true }, half));
            list.AddRange(Enumerable.Repeat(new Cell(), half));

            while (list.Count != numberOfCellsToGenerate)
            {
                list.Add(new Cell());
            }

            return list;
        }

    }
}