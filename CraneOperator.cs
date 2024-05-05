using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternshipApp
{
    public class CraneOperator
    {
        private List<Stack<Crate>> stacks;

        public CraneOperator(List<Stack<Crate>> initialStacks)
        {
            stacks = initialStacks;
        }

        public void PerformRearrangement(List<MoveModel> moves)
        {
            foreach (MoveModel move in moves)
            {
                int fromStackIndex = move.From;
                int toStackIndex = move.To;

                // Validate stack indices
                if (fromStackIndex < 0 || fromStackIndex >= stacks.Count ||
                    toStackIndex < 0 || toStackIndex >= stacks.Count)
                {
                    Console.WriteLine("Invalid stack index in move: " + move);
                    continue; // Skip this move
                }

                // Perform the move if the source stack is not empty
                if (stacks[fromStackIndex].Count > 0)
                {
                    Crate crate = stacks[fromStackIndex].Pop();
                    stacks[toStackIndex].Push(crate);
                }
                else
                {
                    Console.WriteLine("Source stack is empty in move: " + move);
                }
            }
        }

        public List<Crate> GetTopCrates()
        {
            List<Crate> topCrates = new List<Crate>();
            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                {
                    topCrates.Add(stack.Peek());
                }
                else
                {
                    // Placeholder for empty stack
                    topCrates.Add(new Crate('-'));
                }
            }
            return topCrates;
        }
    }
}
