using ExpenseManager.Commands.InAccount;
using ExpenseManager.Commands.Interfaces;
using ExpenseManager.Commands.OutAccount;
using ExpenseManager.Models;

namespace ExpenseManager.Commands
{
    public class Command
    {
        public static SystemStatus Resolve(string input)
        {
            ICommand command = input switch
            {
                "quit" => new Quit(),
                "help" => new Help(),
                _ => ResolveByStatus(input),
            };

            return command.Start();
        }

        private static ICommand ResolveByStatus(string input)
        {
            return Program.Status switch
            {
                SystemStatus.Start => StartCommand.Resolve(input),
                SystemStatus.InAccount => InAccountCommand.Resolve(input),
                _ => new UnknownCommand(),
            };
        }
    }
}
