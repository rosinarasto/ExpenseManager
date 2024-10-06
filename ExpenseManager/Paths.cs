using System.Diagnostics;

namespace ExpenseManager
{
    public record Paths
    {
        public static readonly string USERS_PATH = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", "users.json");
        public static readonly string STATISTCS_FILE = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", "statistics.png");

        public static string GetAccountPath(string accountName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", $"{accountName}_data.json");
        }
    }
}
