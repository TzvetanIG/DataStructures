namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequence
    {
        static void Main()
        {
            const int CountOfMembers = 50;
            var input = Console.ReadLine();
            var n = int.Parse(input);

            var queue = new Queue<int>();
            queue.Enqueue(n);

            var sequence = new List<int>();
            var counter = 1;

            while (counter < CountOfMembers)
            {
                counter+=3;
                var firstNumber = queue.Dequeue();
                queue.Enqueue(firstNumber + 1);
                queue.Enqueue(2 * firstNumber + 1);
                queue.Enqueue(firstNumber + 2);
                sequence.Add(firstNumber);
            }

            Console.WriteLine(string.Join(", ", sequence) + ", " + string.Join(", ", queue));
        }
    }
}
