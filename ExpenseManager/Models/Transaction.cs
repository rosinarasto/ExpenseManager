using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExpenseManager.Models
{
    public record Transaction
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        public int Value { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }


        [JsonConstructor]
        public Transaction(TransactionType Type, int Value, string Category, string Date)
        {
            this.Type = Type;
            this.Value = Value;
            this.Category = Category;
            this.Date = Date;
        }

        public Transaction(TransactionType Type, int Value, string Category) : this(Type, Value, Category, DateTime.Now.ToString("dd/MM/yyyy")) { }
    }
}
