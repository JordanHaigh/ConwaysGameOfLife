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
        //public IList<List<Cell>> Board { get; set; }

        public Cell[,] Board { get; set; }

        public IEnumerable<List<Cell>> Rows
        {
            get
            {
                for (int y = 0; y < Height; y++)
                {
                    var row = new List<Cell>();
                    for (int x = 0; x < Width; x++)
                    {
                        row.Add(Board[x,y]);
                    }

                    yield return row;
                }
            }
        }

        public GameOfLifeBoard(int width, int height, ICellGenerationStrategy generator = null)
        {
            //Ability to specify a Cell Generation strategy or not
            _generator = generator ?? new CellGenerator();
            Width = width;
            Height = height;

            GenerateState();
        }

        private void GenerateState()
        {
            var bagOfCells = new Stack<Cell>(_generator.GenerateCells(Width * Height));

            //Board = new List<List<Cell>>();
            Board = new Cell[Width,Height];

            for (var y = 0; y < Height; y++)
            {
                //var row = new List<Cell>();
                for (var x = 0; x < Width; x++)
                {
                    var cell = bagOfCells.Pop();
                    cell.X = x;
                    cell.Y = y;
                    Board[x, y] = cell;
                    //row.Add(cell);
                }

                //Board.Add(row);
            }
        }

        public void Step()
        {
            var targetState = new Cell[Width, Height];

            for (int y = 0; y < Board.GetLength(0); y++) //Traversal over multidimensional array
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    var cell = Board[x, y];
                    var newCellState = DetermineCellState(cell);
                    targetState[x, y] = newCellState;
                }
            }
            Board = targetState;

        }

        private static Cell DetermineCellState(Cell cell)
        {
            if (cell.IsAlive)
                return new Cell {IsAlive = false, X = cell.X, Y = cell.Y};
            else
                return new Cell { IsAlive = true, X = cell.X, Y = cell.Y };

        }
    }

}