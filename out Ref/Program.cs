using System.IO;
using System;
public class Program
{
    public static void update(out int a)
    {
        a = 10;
    }
    public static void change(ref int d)
    {
        d = 11;
    }
    public static void Main()
    {
        //Console.WriteLine("Enter your age:");
        //int age = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Your age is: " + age);

        int b;
        int c = 9;
        Program p1 = new Program();
        update(out b);
        change(ref c);
        Console.WriteLine("Updated value is: {0}", b);
        Console.WriteLine("Changed value is: {0}", c);
    }
}

//Following are some of the important differences between ref and out keywords.

//Sr. No.	Key	ref keyword	out keyword
//1	Purpose	ref keyword is used when a called method has to update the passed parameter.	out keyword is used when a called method has to update multiple parameter passed.
//2	Direction	ref keyword is used to pass data in bi-directional way.	out keyword is used to get data in uni-directional way.
//3	Initialization	Before passing a variable as ref, it is required to be initialized otherwise compiler will throw error.	No need to initialize variable if out keyword is used.
//4	Initialization	In called method, it is not required to initialize the parameter passed as ref.	In called method, it is required to initialize the parameter passed as out.