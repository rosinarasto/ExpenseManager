using ExpenseManager.Commands.OutAccount;
using Newtonsoft.Json;

namespace ExpenseManager.Services
{
    public static class DataUpdater
    {
        public static async void Users(object sender, EventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(StartCommand.Users);
            await File.WriteAllTextAsync(Paths.USERS_PATH, jsonString);
        }

        public static async void Account(object sender, EventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(LogIn.Account);
            await File.WriteAllTextAsync(Paths.GetAccountPath(LogIn.Account.Username), jsonString);
        }
    }
}
