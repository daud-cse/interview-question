using System;
using System.Text;

namespace StringAndStringBuilderMutableAndImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            //String
            //  Strings are immutable, which means we are creating new memory every time instead of working on existing memory.
            //  So, whenever we are modifying a value of the existing string, i.e., we are creating a
            //    new object which refers to that modified string and the old one becomes 
            //    unreferenced.Hence, if we are modifying the existing string continuously, 
            //    then numbers of the unreferenced object will be increased and it will wait 
            //    for the garbage collector to free the unreferenced object and our application
            //    performance will be decreased.

           string str = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                str += "Modified ";
            }
            Console.WriteLine("String immutable " + str);

            //StringBuilder StringBuilder is a mutable type, that means we are using the same memory
            //location and keep on appending/ modifying the stuff to one instance.
            //It will not create any further instances hence it will not decrease 
            //the performance of the application.

            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                strB.Append("Modified ");
            }
            Console.WriteLine("StringBuilder mutable " + str);
        }
    }
}
