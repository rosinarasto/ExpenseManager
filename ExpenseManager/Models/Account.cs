using Newtonsoft.Json;

namespace ExpenseManager.Models
{
    public record Account
    {
        public string Username { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<string> ExpenseCategories { get; set; }
        public List<string> IncomeCategories { get; set; }

        public Account(string username) : this(username, [], ["Rent", "Utilities"], ["Salary"]) { }

        [JsonConstructor]
        public Account(string Username, List<Transaction> Transactions, List<string> ExpenseCategories, List<string> IncomeCategories)
        {
            this.Username = Username;
            this.Transactions = Transactions;
            this.ExpenseCategories = ExpenseCategories;
            this.IncomeCategories = IncomeCategories;
        }
    }
}
