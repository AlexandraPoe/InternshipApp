using InternshipApp.Models;
using System;
using System.Collections.Generic;

namespace InternshipApp
{
    public class StackReader
    {
        public static List<Stack<Crate>> ParseInitialStacks(List<string> inputLines)
        {
            List<Stack<Crate>> initialStacks = new List<Stack<Crate>>();
            int numStacks = int.Parse(inputLines[0]); // Number of stacks
            string lineWithSpaces = inputLines[1]; // Line with spaces

            // Create additional stacks from 1 to numStacks
            for (int i = 0; i < numStacks; i++)
            {
                initialStacks.Add(new Stack<Crate>());
            }

            // Parse each line and fill the corresponding stack
            for (int i = 2; i < inputLines.Count; i++)
            {
                string line = inputLines[i];
                Stack<Crate> stack = new Stack<Crate>();
                for (int j = 0; j < line.Length; j++)
                {
                    char symbol = line[j];
                    if (symbol != ' ') // Ignore spaces
                    {
                        stack.Push(new Crate(symbol));
                    }
                }
                initialStacks[i - 2] = stack;
            }
            return initialStacks;
        }
    }
}
