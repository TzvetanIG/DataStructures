namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumber
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var stack = new Stack<int>(numbers);
            while (stack.Count > 0)
            {
                var number = stack.Pop();
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
