// See https://aka.ms/new-console-template for more information



//static void Main(String[] args)
//{
    
//}


class Program
{

    delegate double CalAreapointer(int r);
    //static CalAreapointer cpointer = CalculateArea;
    static void Main(string[] args)
    {
        /// cpointer.Invoke(20);
        /// 
        //lemda Expression
        CalAreapointer Cpointer = r => 3.12 * r * r;
       var area= Cpointer(20);

        Func<double,double> func= x => x * x;
        Console.WriteLine(func(5));

        Action<int> action= x => Console.WriteLine(x);
        action(45);
        Predicate<int> predicate= x => x>5;
        Console.WriteLine(predicate(5));
    }
    //static double CalculateArea(int r)
    //{
    //    return 3.14 * r * r;
    //}
  
}
