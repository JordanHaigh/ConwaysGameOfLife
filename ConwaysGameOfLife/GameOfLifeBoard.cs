using System.Collections;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class GameOfLifeBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<List<Cell>> Rows { get; set; }

        public GameOfLifeBoard(int width, int height)
        {
            Width = width;
            Height = height;

            GenerateState();
        }

        private void GenerateState()
        {
            Rows = new List<List<Cell>>();

            for (var y = 0; y < Height; y++)
            {
                var row = new List<Cell>();
                for (var x = 0; x < Width; x++)
                {
                    var cell = GenerateInitialState();
                    row.Add(cell);
                }

                Rows.Add(row);
            }
        }

        private static Cell GenerateInitialState()
        {
            return new Cell();
        }
    }
}