using ExpenseManager.Models;

namespace ExpenseManager.Commands.Interfaces
{
    public interface ICommand
    {
        public SystemStatus Start();
    }
}
