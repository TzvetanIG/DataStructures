using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementLinkedList
{
    using System.Runtime.InteropServices;

    class TestLinkedList
    {
        static void Main()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            Console.WriteLine(list.Remove(2));
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine(list.FirstIndexOf(1));
            Console.WriteLine(list.FirstIndexOf(4));

            Console.WriteLine();
            Console.WriteLine(list.LastIndexOf(1));
            Console.WriteLine(list.LastIndexOf(4));
        }
    }
}
