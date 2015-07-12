namespace LongestSubsequence
{
    using System;
    using System.Linq;

    class LongestSubsequence
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var start = -1;
            var length = 1;
            var maxLength = 1;
            var startLongestSequence = 0;
            var sequenceLength = numbers.Count;
            for (int i = 0; i < sequenceLength - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    if (start == -1)
                    {
                        start = i;
                    }

                    length++;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        startLongestSequence = start;
                    }
                }
                else
                {
                    length = 1;
                    start = -1;
                }
            }
            
            for (int i = startLongestSequence; i < startLongestSequence + maxLength; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
