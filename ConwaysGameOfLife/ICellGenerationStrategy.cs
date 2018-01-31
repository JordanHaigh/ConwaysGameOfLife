using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public interface ICellGenerationStrategy
    {
        List<Cell> GenerateCells(int numberOfCellsToGenerate);

    }
}