using ST10439055_PROG_POE;

internal class Program
{
    private static void Main(string[] args)
    {
        Functions functions = new Functions();
        Console.ForegroundColor = ConsoleColor.Magenta;
        functions.WelcomeMessage();
        functions.PlayVoice();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        string userName = functions.GreetUser();

        while (true)
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Stitch: Please type something!");
                continue;
            }

            if (userInput.ToLower().Contains("bye") ||
                userInput.ToLower().Contains("exit") ||
                userInput.ToLower().Contains("end") ||
                userInput.ToLower().Contains("quit"))
            {
                Console.WriteLine($"Stitch: Goodbye {userName}! Stay secure!");
                break;
            }

            functions.HandleUserInput(userInput);
        }
    }
}