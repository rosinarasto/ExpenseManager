using ExpenseManager.IO.Interfaces;

namespace ExpenseManager.IO
{
    public class ConsoleManager : IIOManager
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public bool ReadLine(out string? buffer)
        {
            buffer = Console.ReadLine();
            
            if (buffer == null) 
            {
                return false;
            }

            buffer = buffer.Trim();
            return true;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void SetColor(string color)
        {
            Console.ForegroundColor = color switch
            {
                "red" => ConsoleColor.Red,
                "green" => ConsoleColor.Green,
                "white" => ConsoleColor.White,
                _ => ConsoleColor.White,
            };
        }
    }
}
