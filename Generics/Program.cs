using System.IO;
using System;
class Program
{
    // source https://www.youtube.com/watch?v=Smen_mwCaic

    //Generics allows us to make classes and mthods --type independent or type safe.
     static void Main()
    {
        //Problem 
        bool equal = CalculatorNonGeneric.AreEqual(4, 4);
        //bool strequal = CalculatorNonGeneric.AreEqual("Interview", "Happy");
        Console.WriteLine("Non Generic:"+ equal);

        //Solve boxing
        bool equalboxing = CalculatorGenericSolveByUseBoxing.AreEqual(4, 4);
        bool strequalboxing = CalculatorGenericSolveByUseBoxing.AreEqual("Interview", "Happy");
        Console.WriteLine("Solve Generic use boxing:" + equal +" "+ strequalboxing);

        //Solve use method Generic
        bool equaluseGeneric = CalculatorGenericSolveByUseMethodGeneric.AreEqual(4, 4);
        bool strequaluseGeneric = CalculatorGenericSolveByUseMethodGeneric.AreEqual("Interview", "Happy");
        Console.WriteLine("Solve use method Generic:" + equal + " " + strequaluseGeneric);
        //Solve use class Generic
        bool equaluseClassGeneric = CalculatorGenericSolveByUseClassGeneric<int>.AreEqual(4, 4);
        bool strequaluseClassGeneric = CalculatorGenericSolveByUseClassGeneric<string>.AreEqual("Interview", "Happy");
        Console.WriteLine("Solve use Class Generic:" + equal + " " + strequaluseClassGeneric);
    }
}

//Problem 
class CalculatorNonGeneric
{
    //bool strequal = CalculatorNonGeneric.AreEqual("Interview", "Happy");
    public static bool AreEqual(int v1, int v2)
    {
        return v1.Equals(v2);
    }
}
// solve Problem use boxing
//The problem with this is, it involves boxing from converting int (value) to object (reference) type.
// This will impact the performance
class CalculatorGenericSolveByUseBoxing
{
    //bool strequal = CalculatorNonGeneric.AreEqual("Interview", "Happy");
    public static bool AreEqual(object v1, object v2)
    {
        return v1.Equals(v2);
    }
}
//Solve the use method Generic
class CalculatorGenericSolveByUseMethodGeneric
{
    //bool strequal = CalculatorNonGeneric.AreEqual("Interview", "Happy");
    public static bool AreEqual<T>(T v1, T v2)
    {
        return v1.Equals(v2);
    }
}
//Solve the use class Generic
//when you are making calss generic all thr method inside the class will be generic.
class CalculatorGenericSolveByUseClassGeneric<T>
{
    //bool strequal = CalculatorNonGeneric.AreEqual("Interview", "Happy");
    public static bool AreEqual(T v1, T v2)
    {
        return v1.Equals(v2);
    }
}
