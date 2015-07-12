namespace SumAndAverage
{
    using System;
    using System.Linq;

    internal class SumAndAverage
    {
        private static void Main()
        {
            var input = Console.ReadLine();

            int sum;
            double average;
            if (input != "")
            {
                var numbers = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                sum = numbers.Sum();
                average = numbers.Average();
            }
            else
            {
                sum = 0;
                average = 0;
            }


            Console.WriteLine("Sum = {0}; Average = {1}", sum, average);
        }
    }
}
