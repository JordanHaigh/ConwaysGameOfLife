using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new GameOfLifeBoard(50, 50);
            var renderer = new GameBoardRenderer();

            for (int i = 0; i < 100; i++)
            {
                var output = renderer.Render(board);

                Console.Clear();

                foreach (var line in output)
                {
                    Console.WriteLine(line);
                }

                Thread.Sleep(500);
                board.Step();

            }



        }
    }
}

    /*

    Scenario 3:

    As a *living cell*
    When the game ticks
    I change state

    Accept:
    If cell has < 2 living neighbours, cell dies
    If cell has > 3 living neighbours, cell dies
    If cell has 2-3 living neighbours, cell lives
    Scenario 4:

    As a *dead or empty cell*
    When the game ticks
    I change state

    Accept:
    If cell has 3 living neighbours, cell lives
     * 
     * 
    */



