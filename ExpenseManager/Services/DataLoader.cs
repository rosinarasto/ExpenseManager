using ExpenseManager.Models;
using Newtonsoft.Json;

namespace ExpenseManager.Services
{
    public class DataLoader
    {
        public static List<User> GetUsers()
        {
            if (!File.Exists(Paths.USERS_PATH))
            {
                File.Create(Paths.USERS_PATH).Dispose();
            }

            string jsonData = File.ReadAllText(Paths.USERS_PATH);
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? ([]);
        }

        public static Account GetAccount(string accountName)
        {
            if (!File.Exists(Paths.GetAccountPath(accountName)))
            {
                File.Create(Paths.GetAccountPath(accountName)).Dispose();
            }

            string jsonData = File.ReadAllText(Paths.GetAccountPath(accountName));
            return JsonConvert.DeserializeObject<Account>(jsonData) ?? new Account(accountName);
        }
    }
}
