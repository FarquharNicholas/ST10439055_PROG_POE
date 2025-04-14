using ST10439055_PROG_POE;

internal class Program
{
    private static void Main(string[] args)
    {
        Functions Functions = new Functions();
        Console.WriteLine("Hello, World!");
        Functions.WelcomeMessage();
        Functions.GreetUser();
    }
}