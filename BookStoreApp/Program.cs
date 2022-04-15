using System;

namespace BookStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Commands: l (list), u (change url), r (resetDb) and e (exit) - add -l to first two for logs");
            Console.Write(
                "Checking if database exists... ");
            Console.WriteLine(Commands.WipeCreateSeed(true) ? "created database and seeded it." : "it exists.");
            do
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "l":
                        Commands.ListAll();
                        break;
                    case "u":
                        Commands.ChangeWebUrl();
                        break;
                    case "l -l":
                        Commands.ListAllWithLogs();
                        break;
                    case "u -l":
                        Commands.ChangeWebUrlWithLogs();
                        break;
                    case "r":
                        Commands.WipeCreateSeed(false);
                        break;
                    case "e":
                        return;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            } while (true);
        }
    }
}
