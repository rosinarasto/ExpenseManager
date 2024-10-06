using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Commands.OutAccount;
using ExpenseManager.Models;

namespace ExpenseManager.Commands.InAccount
{
    public class AccountStatus : ICommand
    {
        public SystemStatus Start()
        {
            var balance =
                LogIn.Account.Transactions.Where(tr => tr.Type == TransactionType.Income).Select(tr => tr.Value).Sum() -
                LogIn.Account.Transactions.Where(tr => tr.Type == TransactionType.Expense).Select(tr => tr.Value).Sum();

            Program.IOManager.WriteLine($"Balance: {balance}");
            
            var transactions = FilterTransactions(LogIn.Account.Transactions);
            int categoryIndent = transactions.Count != 0 ? transactions.Select(tr => tr.Category).Max(ct => ct.Length) : 0;
            transactions.Reverse();
            
            Program.IOManager.WriteLine("Transactions:");

            foreach (var transaction in transactions)
            {
                Program.IOManager.SetColor(transaction.Type == TransactionType.Income ? "green" : "red");
                var value = transaction.Type == TransactionType.Income ? transaction.Value : -transaction.Value;
                Program.IOManager.WriteLine(
                    string.Format($"{{0, {-categoryIndent}}} | {transaction.Date} | {value}", transaction.Category));
            }

            Program.IOManager.SetColor();

            return Program.Status;
        }

        private static List<Transaction> FilterTransactions(List<Transaction> transactions)
        {
            if (!FilterCheck(""))
            {
                return transactions;
            }

            transactions = FilterByCategory(transactions);
            transactions = FilterByValue(transactions);
            transactions = FilterByDate(transactions);

            return transactions;
        }

        private static List<Transaction> FilterByDate(List<Transaction> transactions)
        {
            if (!FilterCheck(" by date"))
            {
                return transactions;
            }

            Program.IOManager.WriteLine("Enter value as 'dd' (for day filter), 'mm' (for month filter)" +
                                        "and 'yyyy' (for year filter) value or 'NaN' if value won't be defined.");
            Program.IOManager.Write("[day]: ");
            Program.IOManager.ReadLine(out string day);
            Program.IOManager.Write("[month]: ");
            Program.IOManager.ReadLine(out string month);
            Program.IOManager.Write("[year]: ");
            Program.IOManager.ReadLine(out string year);

            return transactions.Where(x => day.Equals("NaN") || day.Equals(x.Date.Split("/")[0]))
                               .Where(x => month.Equals("NaN") || month.Equals(x.Date.Split("/")[1]))
                               .Where(x => year.Equals("NaN") || year.Equals(x.Date.Split("/")[2]))
                               .ToList();
        }

        private static List<Transaction> FilterByValue(List<Transaction> transactions)
        {
            if (!FilterCheck(" by value"))
            {
                return transactions;
            }

            Program.IOManager.WriteLine("Enter boundary as a numeric value or 'NaN' if boundary won't be defined.");

            int lower_boundary = int.MinValue;
            int upper_boundary = int.MaxValue;

            while (true)
            {
                Program.IOManager.Write("[lower boundary]: ");
                Program.IOManager.ReadLine(out string lower);

                Program.IOManager.Write("[upper boundary]: ");
                Program.IOManager.ReadLine(out string upper);

                if ((int.TryParse(lower, out lower_boundary) || "NaN".Equals(lower_boundary)) &&
                    (int.TryParse(upper, out upper_boundary) || "NaN".Equals(upper_boundary)))
                {
                    break;
                }

                Program.IOManager.WriteLine("You entered invalid values into boundary fields.");
            }

            return transactions.Where(x => x.Value >= lower_boundary && x.Value <= upper_boundary).ToList();
        }

        private static List<Transaction> FilterByCategory(List<Transaction> transactions)
        {
            if (!FilterCheck(" by category"))
            {
                return transactions;
            }

            Program.IOManager.Write("[category]: ");
            Program.IOManager.ReadLine(out string input);

            return transactions.Where(x => x.Category.ToLower().Equals(input?.ToLower())).ToList();
        }

        private static bool FilterCheck(string question)
        {
            Program.IOManager.Write($"Do you want to filter transactions{question}? (Y/n) ");
            Program.IOManager.ReadLine(out string input);

            return "Y".Equals(input);
        }
    }
}

