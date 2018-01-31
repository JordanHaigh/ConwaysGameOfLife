using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
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



