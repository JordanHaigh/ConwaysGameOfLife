using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConwaysGameOfLife
{
    public class GameOfLifeBoard
    {
        private ICellGenerationStrategy _generator;
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<List<Cell>> Rows { get; set; }

        public GameOfLifeBoard(int width, int height, ICellGenerationStrategy generator = null)
        {
            _generator = generator ?? new CellGenerator();
            Width = width;
            Height = height;

            GenerateState();
        }

        private void GenerateState()
        {
            var bagOfCells = new Stack<Cell>(_generator.GenerateCells(Width * Height));

            Rows = new List<List<Cell>>();

            for (var y = 0; y < Height; y++)
            {
                var row = new List<Cell>();
                for (var x = 0; x < Width; x++)
                {
                    row.Add(bagOfCells.Pop());
                }

                Rows.Add(row);
            }
        }

    }
}