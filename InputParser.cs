using InternshipApp.Models;

namespace InternshipApp.InternshipTest
{
    public class InputParser
    {
        public static List<Stack<Crate>> ParseInitialStacks(List<string> inputLines)
        {
            List<Stack<Crate>> initialStacks = new List<Stack<Crate>>();
            foreach (string line in inputLines)
            {
                Stack<Crate> stack = new Stack<Crate>();
                foreach (char c in line)
                {
                    if (char.IsLetter(c))
                    {
                        stack.Push(new Crate(c));
                    }
                }
                initialStacks.Add(stack);
            }
            return initialStacks;
        }

        public static List<MoveModel> ParseMoves(List<string> inputLines)
        {
            List<MoveModel> moves = new List<MoveModel>();
            bool readingMoves = false;
            foreach (string line in inputLines)
            {
                if (readingMoves)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 4 && parts[0] == "move")
                    {
                        int numCrates = int.Parse(parts[1]);
                        int fromStackIndex = int.Parse(parts[3]) - 1;
                        int toStackIndex = int.Parse(parts[5]) - 1;
                        moves.Add(new MoveModel { NumCrates = numCrates, From = fromStackIndex, To = toStackIndex });
                    }
                }
                else if (line.StartsWith("move"))
                {
                    readingMoves = true;
                }
            }
            return moves;
        }
    }
}