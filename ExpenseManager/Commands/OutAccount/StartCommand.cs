using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Models;
using ExpenseManager.Services;

namespace ExpenseManager.Commands.OutAccount
{
    public abstract class StartCommand : ICommand
    {
        public static List<User> Users { get; set; } = DataLoader.GetUsers();

        protected string? username;
        protected string? password;

        public static ICommand Resolve(string input)
        {
            return input switch
            {
                "log-in" => new LogIn(),
                "sign-up" => new SignUp(),
                _ => new UnknownCommand(),
            };
        }

        public virtual SystemStatus Start()
        {
            Program.IOManager.WriteLine("Enter username and password:");
            Program.IOManager.Write("[username]: ");

            if (!Program.IOManager.ReadLine(out username))
            {
                return Program.Status;
            }

            Program.IOManager.Write("[password]: ");

            if (!Program.IOManager.ReadLine(out password))
            {
                return Program.Status;
            }

            return Program.Status;
        }
    }
}
