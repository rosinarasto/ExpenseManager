using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Commands.OutAccount;
using ExpenseManager.Models;

namespace ExpenseManager.Commands.InAccount
{
    public abstract class InAccountCommand
    {

        public static ICommand Resolve(string input)
        {
            return input switch
            {
                "log-out" => new LogOut(),
                "add-income" => new AddTransaction(LogIn.Account.IncomeCategories, TransactionType.Income),
                "add-expense" => new AddTransaction(LogIn.Account.ExpenseCategories, TransactionType.Expense),
                "account-status" => new AccountStatus(),
                "add-income-category" => new AddCategory(LogIn.Account.IncomeCategories),
                "add-expense-category" => new AddCategory(LogIn.Account.ExpenseCategories),
                "statistics" => new Statistics(),
                _ => new UnknownCommand(),
            };
        }
    }
}
