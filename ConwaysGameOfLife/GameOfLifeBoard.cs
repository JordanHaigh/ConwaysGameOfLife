using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConwaysGameOfLife
{
    public class GameOfLifeBoard
    {
        private ICellGenerationStrategy _generator;
        public int Width { get; set; }
        public int Height { get; set; }

        public Cell[,] Board { get; set; }

        /*public IEnumerable<List<Cell>> Rows
        {
            get
            {
                for (int y = 0; y < Height; y++)
                {
                    var row = new List<Cell>();
                    for (int x = 0; x < Width; x++)
                    {
                        var thisCell = Board[x, y];
                        row.Add(thisCell);
                    }

                    yield return row;
                }
            }
        }*/

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

            Board = new Cell[Width,Height];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var cell = bagOfCells.Pop();
                    Board[x, y] = cell;
                }

            }
        }

        public void Step()
        {
            var targetState = new Cell[Width, Height];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var existingCell = Board[x, y];
                    var newCellState = DetermineCellState(existingCell, x, y);
                    targetState[x, y] = newCellState;
                }
            }

            Board = targetState;

        }

        private Cell DetermineCellState(Cell cell, int x, int y)
        {
            var neighbours = GetNeighbours(x, y);
            var livingNeighbours = neighbours.Count(c => c.IsAlive);

            if (cell.IsAlive)
            {
                if (livingNeighbours < 2 || livingNeighbours > 3)
                    return new Cell { IsAlive = false };

                if (livingNeighbours == 2 || livingNeighbours == 3)
                    return new Cell { IsAlive = true }; //Cell Lives

            }
            else
            {
                if(livingNeighbours == 3)
                    return new Cell { IsAlive = true }; //Cell Lives
                else
                    return new Cell { IsAlive = false };

            }


            throw new InvalidOperationException();

        }

        private List<Cell> GetNeighbours(int x, int y)
        {
            var coords =  new List<Coord>
            {
                new Coord(x - 1, y - 1), //North West
                new Coord(x - 1, y), //West
                new Coord(x - 1, y + 1), //South West

                new Coord(x, y - 1), //North
                new Coord(x, y + 1), //South

                new Coord(x + 1, y - 1), //North East
                new Coord(x + 1, y), //East
                new Coord(x + 1, y + 1), //South East
            };


            var neighbours = new List<Cell>();
            foreach (var pair in coords)
            {
                try
                {
                    var neighbourCell = Board[pair.X, pair.Y];
                    neighbours.Add(neighbourCell);
                }
                catch 
                {
                    //Index out of bounds
                }
                
            }

            return neighbours;

        }
    }

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}