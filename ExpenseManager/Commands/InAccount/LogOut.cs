using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;

namespace ExpenseManager.Commands.InAccount
{
    public class LogOut : ICommand
    {
        public SystemStatus Start()
        {
            Program.IOManager.WriteLine("You were successfully loged out.");
            return SystemStatus.Start;
        }
    }
}
