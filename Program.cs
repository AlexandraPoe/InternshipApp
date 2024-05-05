
using InternshipApp.InternshipTest;
using InternshipApp.Models;
using System;
using System.Collections.Generic;

namespace InternshipApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLines = new List<string>
            {
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 "
            };

            List<Stack<Crate>> initialStacks = InputParser.ParseInitialStacks(inputLines);
            CraneOperator craneOperator = new CraneOperator(initialStacks);

            List<string> moveLines = new List<string>
            {
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2"
            };

            List<MoveModel> moves = InputParser.ParseMoves(moveLines);

            craneOperator.PerformRearrangement(moves);

            List<Crate> topCrates = craneOperator.GetTopCrates();

            foreach (Crate crate in topCrates)
            {
                if (crate.Symbol != '-')
                {
                    Console.Write(crate.Symbol);
                }
            }
        }
    }
}