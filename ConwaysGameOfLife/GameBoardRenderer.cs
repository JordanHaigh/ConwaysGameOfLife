using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwaysGameOfLife
{
    public class GameBoardRenderer
    {
        public List<string> Render(GameOfLifeBoard gameOfLifeBoard)
        {
            if(gameOfLifeBoard == null)
                throw new ArgumentException("Gameboard cannot be rendered.");

            var outputLine =  new List<string>();

            foreach (var row in gameOfLifeBoard.Rows)
            {
                var buffer = new StringBuilder();
                foreach (var cell in row)
                {
                    buffer.Append(cell.IsAlive ? "#" : "-");
                }

                outputLine.Add(buffer.ToString());
            }

            return outputLine;

        }
    }
}