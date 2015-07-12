namespace ImplementTheDataStructureReversedList
{
    using System;

    class TestReversedList
    {
        static void Main()
        {
            var list = new ReversedList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Remove(2);
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
