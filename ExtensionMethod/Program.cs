using System;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string demo = "this is demo";
            demo.printToConsole();
            Console.WriteLine("Hello World!");
        }
    }
    public static class Extensions
    {
        public static void printToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }
}
