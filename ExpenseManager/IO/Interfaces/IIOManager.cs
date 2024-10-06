namespace ExpenseManager.IO.Interfaces
{
    public interface IIOManager
    {
        void WriteLine(string msg = "");
        void Write(string msg = "");
        bool ReadLine(out string? buffer);
        void Clear();
        void SetColor(string color = "white");
    }
}
