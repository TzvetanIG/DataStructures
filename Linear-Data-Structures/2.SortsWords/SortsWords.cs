namespace SortsWords
{
    using System;
    using System.Linq;

    class SortsWords
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var words = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var sortedWords = words
                .OrderBy(w => w)
                .ToList();

            Console.WriteLine(string.Join(" ", sortedWords));
        }
    }
}
