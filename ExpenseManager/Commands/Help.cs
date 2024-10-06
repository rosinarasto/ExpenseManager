using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;

namespace ExpenseManager.Commands
{
    public class Help : ICommand
    {
        public SystemStatus Start()
        {
            Program.IOManager.WriteLine("Available commands:");

            switch (Program.Status)
            {
                case SystemStatus.Start:
                    StartMenu();
                    break;
                case SystemStatus.InAccount:
                    InAccountMenu();
                    break;
                default:
                    Program.IOManager.WriteLine("-");
                    break;
            }

            return Program.Status;
        }

        private static void InAccountMenu()
        {
            Program.IOManager.WriteLine("'log-out' -> Logs out from your account.");
            Program.IOManager.WriteLine("'add-income' -> Adds income to your account.You have to enter value and category of income.");
            Program.IOManager.WriteLine("'add-expense' -> Adds expense to your account. You have to enter value and category of expense.");
            Program.IOManager.WriteLine("'account-status' -> Shows you status of your account.");
            Program.IOManager.WriteLine("'add-income-category' -> Adds category for income.");
            Program.IOManager.WriteLine("'add-expense-category' -> Adds category for expense.");
            Program.IOManager.WriteLine("'statistics' -> Shows you some stats about your account.");
        }

        private static void StartMenu()
        {
            Program.IOManager.WriteLine("'log-in' -> Logs in into your account in Expense Manager.");
            Program.IOManager.WriteLine("'sign-up' -> Signs up for new account in Expense Manager.");
        }
    }
}
