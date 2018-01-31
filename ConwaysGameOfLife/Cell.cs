using System;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Cell()
        {
            Id = Guid.NewGuid();
            X = Int32.MinValue;
            Y = Int32.MinValue;
        }

    }
}