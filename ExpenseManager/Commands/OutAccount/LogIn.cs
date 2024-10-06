using ExpenseManager.Models;
using ExpenseManager.Services;

namespace ExpenseManager.Commands.OutAccount
{
    public class LogIn : StartCommand
    {
        public static Account Account { get; set; }

        public override SystemStatus Start()
        {
            base.Start();

            var users = Users.Where(user => Equals(username, user.Username)).ToList();

            if (users.Count == 0 || !Equals(User.HashPassword(password, users.First().Salt), users.First().Password))
            {
                Program.IOManager.WriteLine("Invalid username or password.");
                return Program.Status;
            }

            Program.IOManager.WriteLine("You were successfully loged in.");
            Account = DataLoader.GetAccount(username);
            return SystemStatus.InAccount;
        }
    }
}
