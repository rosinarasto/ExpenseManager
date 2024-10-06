using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Commands.OutAccount;
using ExpenseManager.Models;
using ExpenseManager.Services;

namespace ExpenseManager.Commands.InAccount
{
    public class AddTransaction(List<string> categories, TransactionType type) : ICommand
    {
        private event EventHandler AccountChange = DataUpdater.Account;
        private readonly List<string> _categories = categories;
        private readonly TransactionType _type = type;

        public SystemStatus Start()
        {
            Program.IOManager.WriteLine("Enter value.");
            Program.IOManager.Write("[value]: ");

            if (!Program.IOManager.ReadLine(out string input) || !int.TryParse(input, out int num) || num < 0)
            {
                Program.IOManager.WriteLine("Value that you entered has wrong format.");
                return Program.Status;
            }

            Program.IOManager.WriteLine("Categories: ");

            int i = 1;

            foreach (var category in _categories)
            {
                Program.IOManager.WriteLine($"{i}. {category}");
                i++;
            }

            Program.IOManager.WriteLine("Enter number of category you have choosen.");
            Program.IOManager.Write("[category]: ");

            if (!Program.IOManager.ReadLine(out input) || !int.TryParse(input, out int cat) || cat < 1 || cat > _categories.Count)
            {
                Program.IOManager.WriteLine("Category that you entered has wrong format.");
                return Program.Status;
            }

            LogIn.Account.Transactions.Add(new Transaction(_type, num, _categories.ElementAt(cat - 1)));
            AccountChange.Invoke(null, EventArgs.Empty);
            Program.IOManager.WriteLine($"{_type} was successfully added.");
            return Program.Status;
        }
    }
}
