using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Commands.OutAccount;
using ExpenseManager.Models;
using ScottPlot;
using System.Globalization;

namespace ExpenseManager.Commands.InAccount
{
    public class Statistics : ICommand
    {
        public SystemStatus Start()
        {
            Plot myPlot = new();
            var transactions = LogIn.Account.Transactions;
            transactions.Reverse();

            double balance = 0;
            DateTime[] dates = transactions
                .Select(x => DateTime.ParseExact(x.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .ToArray();
            double[] ys = transactions.Select(x =>
            {
                balance += x.Type == TransactionType.Income ? x.Value : -x.Value;
                return balance;
            }).ToArray();
           
            myPlot.Add.Scatter(dates, ys);
            myPlot.Axes.DateTimeTicksBottom();

            myPlot.SavePng(Paths.STATISTCS_FILE, 600, 500);

            Program.IOManager.WriteLine("Graph from statistics command was saved in Data folder.");

            return Program.Status;
        }
    }
}