using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                int outputLength = row.Count;
                var thisRow = string.Join("", Enumerable.Repeat("-", outputLength));
                outputLine.Add(thisRow);
            }

            return outputLine;

        }
    }
}