using System;
using System.Text;

namespace SOLID_PRINCIPLES.LSP
{
    //https://dotnettutorials.net/lesson/liskov-substitution-principle/#:~:text=The%20Liskov%20Substitution%20Principle%20in%20C%23%20states%20that%20even%20the,issue%20with%20our%20software%20design.
    class Program
    {
        static void Main(string[] args)
        {
            Apple apple = new Orange();
            Console.WriteLine(apple.GetColor());
            Apple apple1 = new Apple();
            Console.WriteLine(apple1.GetColor());

            //OrangeLsp fruit1 = new OrangeLsp();
            //Console.WriteLine(fruit1.GetColor());
            //AppleLsp fruit2 = new AppleLsp();
            //Console.WriteLine(fruit2.GetColor());

            ////https://code-maze.com/liskov-substitution-principle/
            // var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            // SumCalculatorNONLSP sum = new SumCalculatorNONLSP(numbers);
            // Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            // Console.WriteLine();
            // SumCalculatorNONLSP evenSum = new EvenNumbersSumCalculator(numbers);
            // Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");

            //https://code-maze.com/liskov-substitution-principle/
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            Calculator sum = new SumCalculatorLSP(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            Console.WriteLine();
            Calculator evenSum = new EvenNumbersSumCalculatorLSP(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");

            Console.ReadLine();
            //https://enlabsoftware.com/development/domain-driven-design-in-asp-net-core-applications.html
            //Fruit fruit = new OrangeLsp();
            //Console.WriteLine(fruit.GetColor());
            //fruit = new AppleLsp();
            //Console.WriteLine(fruit.GetColor());
        }
    }
    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }
    }
    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }

    public abstract class Fruit
    {
        public abstract string GetColor();
    }
    public class AppleLsp : Fruit
    {
        public override string GetColor()
        {
            return "LSP Red";
        }
    }
    public class OrangeLsp : Fruit
    {
        public override string GetColor()
        {
            return "Lsp Orange";
        }
    }

    public abstract class Calculator
    {
        protected readonly int[] _numbers;

        public Calculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public abstract int Calculate();
    }
    public class SumCalculatorLSP : Calculator
    {
        public SumCalculatorLSP(int[] numbers)
            : base(numbers)
        {
        }

        public override int Calculate() => _numbers.Sum();
    }
    public class EvenNumbersSumCalculatorLSP: Calculator
    {
        public EvenNumbersSumCalculatorLSP(int[] numbers)
           : base(numbers)
        {
        }

        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }


    public class SumCalculatorNONLSP
    {
        protected readonly int[] _numbers;

        public SumCalculatorNONLSP(int[] numbers)
        {
            _numbers = numbers;
        }

        public int Calculate() => _numbers.Sum();
    }
    public class EvenNumbersSumCalculator : SumCalculatorNONLSP
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
        }

        public new int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }
}