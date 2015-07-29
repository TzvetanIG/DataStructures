namespace LinkedStack
{
    using System;

    class PlayingWithLinkedStack
    {
        static void Main()
        {

            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            var elements = stack.ToArray();
            Console.WriteLine(string.Join(" ", elements));

            while (stack.Count > 0)
            {
                var number = stack.Pop();
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
