using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class CellGenerator : ICellGenerationStrategy
    {
        public List<Cell> GenerateCells(int numberOfCellsToGenerate)
        {
            //Catering for the scenario where half or less of cells set to alive at random
            var half = numberOfCellsToGenerate / 2;

            var list = new List<Cell>();
            list.AddRange(Enumerable.Repeat(new Cell { IsAlive = true }, half));
            list.AddRange(Enumerable.Repeat(new Cell(), half));

            while (list.Count != numberOfCellsToGenerate)
            {
                list.Add(new Cell());
            }

            //Achieve randomisation
            return list.OrderBy(x=>Guid.NewGuid()).ToList();
        }

    }
}