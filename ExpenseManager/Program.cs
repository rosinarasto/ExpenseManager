using ExpenseManager.IO.Interfaces;
using ExpenseManager.IO;
using ExpenseManager.Commands;
using ExpenseManager.Models;


namespace ExpenseManager
{
    public class Program
    {
        public static IIOManager IOManager { get; } = new ConsoleManager();
        public static SystemStatus Status { get; set; } = SystemStatus.Start;


        public static void Main()
        {
            IOManager.WriteLine("Welcome in Expense Manager");
            IOManager.WriteLine("Anytime enter 'help' to see available commands.");

            MainLoop();
        }

        private static void MainLoop()
        {

            while (Status != SystemStatus.End)
            {
                IOManager.Write(">>> ");
                if (!IOManager.ReadLine(out string? command) || command == null)
                {
                    return;
                }

                Status = Command.Resolve(command);
            }

        }
    }
}
