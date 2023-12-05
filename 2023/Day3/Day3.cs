using AdventOfCode.Utils;
using System.Runtime.CompilerServices;

namespace AdventOfCode._2023.Day3
{
    class Day3 : Solution
    {

        protected override string ExecutePart1(List<string> inputContent)
        {
            char[] ignoredChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];
            int sum = 0;

            List<char> numChars = new();
            List<int> numIndexes = new();


            for (int i = 0; i < inputContent.Count; i++)
            {
                for(int j =0; j < inputContent[i].Length; j++) { 
                    char currentChar = inputContent[i][j];
                    if (char.IsDigit(currentChar))
                    {
                        numChars.Add(currentChar);
                        numIndexes.Add(j);
                    }
                    if (numChars.Count > 0 && (!char.IsDigit(currentChar) || j == inputContent[i].Length - 1))
                    {
                        string numString = new(numChars.ToArray());
                        int number = int.Parse(numString);

                        for (int y = (i - 1) >= 0 ? i - 1 : i;
                                y <= i + 1 && y < inputContent.Count;
                                y++)
                            {
                            bool breakLoop = false;
                            for (int x = (numIndexes[0] - 1) >= 0 ? numIndexes[0] - 1 : numIndexes[0];
                            x <= numIndexes[^1] + 1 && x < inputContent[i].Length;
                            x++)
                            {
                                int xAxis = x;
                                int yAxis = y;
                                char checkedChar = inputContent[y][x];

                                if (!ignoredChars.Contains(inputContent[y][x]))
                                {
                                    sum += number;
                                    breakLoop = true;
                                    break;
                                }
                            }
                            if (breakLoop) break;
                        }
                        number = 0;
                        numChars.Clear();
                        numIndexes.Clear();
                    }
                }
            }

            return sum.ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            return "Not Solved !";
        }
    }
}
