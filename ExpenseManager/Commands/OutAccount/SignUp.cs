using ExpenseManager.Models;
using ExpenseManager.Services;
using System.Security.Cryptography;

namespace ExpenseManager.Commands.OutAccount
{
    public class SignUp : StartCommand
    {
        private event EventHandler UsersChange = DataUpdater.Users;

        public override SystemStatus Start()
        {

            while (true)
            {
                base.Start();

                if (Users.Where(user => Equals(username, user.Username)).Any())
                {
                    Program.IOManager.WriteLine("Entered username is already used.");
                }
                else
                {
                    break;
                }
            }

            SignUpUser(username, password);
            Program.IOManager.WriteLine("You were successfully signed up.");
            return Program.Status;
        }

        private void SignUpUser(string username, string password)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buffer = new byte[1024];

            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            Users.Add(new User(username, User.HashPassword(password, salt), salt));
            UsersChange.Invoke(null, EventArgs.Empty);
        }
    }
}
