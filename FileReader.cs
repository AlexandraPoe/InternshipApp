using System;
using System.Collections.Generic;

namespace InternshipApp
{
    public class FileReader
    {
        public static List<string> ReadInputFromFile(string filePath)
        {
            List<string> inputLines = new List<string>();
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                {
                    string line;
                    bool firstLine = true;
                    int numStacks = 0;
                    string lineWithSpaces = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // Remove leading and trailing spaces
                            line = line.Trim();
                            // Fill a separate stack with characters from the line
                            Stack<char> stack = new Stack<char>(line);
                            // Add the stack representation to the list of input lines
                            inputLines.Add(stack.ToString());
                            if (firstLine)
                            {
                                firstLine = false;
                                // Memorize the line including spaces
                                lineWithSpaces = line;
                                // Memorize the index of the last number element in the line
                                numStacks = line.Trim().Split(' ').Length;
                                // Create additional stacks from 1 to numStacks
                                for (int i = 1; i <= numStacks; i++)
                                {
                                    inputLines.Add("");
                                }
                            }
                        }
                    }
                    // Add the line with spaces to the input lines
                    inputLines.Insert(0, lineWithSpaces);
                    // Add the number of stacks as the first element
                    inputLines.Insert(0, numStacks.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                // You might want to handle the exception more appropriately
            }
            return inputLines;
        }
    }
}
