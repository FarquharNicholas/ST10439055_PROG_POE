using ST10439055_PROG_POE;

internal class Program
{
    private static void Main(string[] args)
    {
        Functions functions = new Functions();

        functions.WelcomeMessage();
        functions.PlayVoice();
        functions.GreetUser();

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
                userInput.ToLower().Contains("quit"))
            {
                Console.WriteLine("Stitch: Goodbye! Stay secure!");
                break;
            }

            functions.HandleUserInput(userInput);
        }
    }
}

