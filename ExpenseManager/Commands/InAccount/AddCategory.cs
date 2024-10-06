using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;
using ExpenseManager.Services;

namespace ExpenseManager.Commands.InAccount
{
    public class AddCategory(List<string> categories) : ICommand
    {
        private event EventHandler AccountChange = DataUpdater.Account;
        private readonly List<string> _categories = categories;

        public SystemStatus Start()
        {
            Program.IOManager.WriteLine("Enter category you want to add.");
            Program.IOManager.Write("[category]: ");

            if (!Program.IOManager.ReadLine(out string input))
            {
                return Program.Status;
            }

            _categories.Add(input);
            Program.IOManager.WriteLine("Category was successfully added.");
            AccountChange?.Invoke(this, EventArgs.Empty);
            return Program.Status;
        }
    }
}