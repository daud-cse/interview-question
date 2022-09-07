class Program
{
    static async Task Main(string[] args)
    {
        //somemethod();
        //Console.WriteLine("main therad");
        //Console.ReadLine();
        await ExecuteAsyncFunctions();
        Console.ReadLine();
    }
    static  void somemethod()
    {
        Task.Delay(20000).Wait();
        Console.WriteLine("Asyc therad finished");
    }
    public static async Task ExecuteAsyncFunctions()
    {
        var firstAsync = FirstAsync();
        var secondAsync = SecondAsync();
        var thirdAsync = ThirdAsync();
        await Task.WhenAll(firstAsync, secondAsync, thirdAsync);
    }
    public static async Task FirstAsync()
    {
        Console.WriteLine("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("First Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }
    public static async Task SecondAsync()
    {
        Console.WriteLine("Second Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("Second Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }
    public static async Task ThirdAsync()
    {
        Console.WriteLine("Third Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("Third Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }
}
