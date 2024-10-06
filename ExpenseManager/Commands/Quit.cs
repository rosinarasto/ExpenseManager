using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;

namespace ExpenseManager.Commands
{
    public class Quit : ICommand
    {
        public SystemStatus Start()
        {
            return SystemStatus.End;
        }
    }
}