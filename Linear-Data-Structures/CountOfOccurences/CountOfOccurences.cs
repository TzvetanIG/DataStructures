namespace CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountOfOccurences
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();

            var length = numbers.Count;
            var count = 1;
            for (int i = 0; i < length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                    if (i == length - 2)
                    {
                        Console.WriteLine("{0} -> {1} times", numbers[i], count);
                    }
                }
                else
                {
                    Console.WriteLine("{0} -> {1} times", numbers[i], count);
                    count = 1;
                    if (i == length - 2)
                    {
                        Console.WriteLine("{0} -> {1} times", numbers[i + 1], count);
                    }
                }
            }
        }
    }
}
