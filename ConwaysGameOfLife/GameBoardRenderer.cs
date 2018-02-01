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

            for (var y = 0; y < gameOfLifeBoard.Height; y++)
            {
                var buffer = new StringBuilder();
                for (var x = 0; x < gameOfLifeBoard.Width; x++)
                {
                    var cell = gameOfLifeBoard.Board[x, y];
                    //Hashes for alive, Dashes for Dead
                    buffer.Append(cell.IsAlive ? "#" : "-");
                }
                outputLine.Add(buffer.ToString());

            }

            return outputLine;

        }
    }
}