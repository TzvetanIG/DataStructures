namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    static class RemoveOddOccurences
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var counts = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }

            var newSequence = numbers
                .Where(n => counts[n] % 2 == 0).ToList();

            Console.WriteLine(string.Join(" ", newSequence));
        }
    }
}
