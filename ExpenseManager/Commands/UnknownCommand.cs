using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;

namespace ExpenseManager.Commands
{
    public class UnknownCommand : ICommand
    {
        public SystemStatus Start()
        {
            Program.IOManager.WriteLine("Unknown command.");
            return Program.Status;
        }
    }
}
