using System.Security.Cryptography;
using System.Text;

namespace ExpenseManager.Models
{
    public class User(string username, string password, string salt)
    {
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
        public string Salt { get; set; } = salt;

        public static string HashPassword(string password, string salt)
        {
            return BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes(password + salt)));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not User)
            {
                return false;
            }

            var tmp = (User)obj;

            return Equals(tmp.Username, Username) && Equals(tmp.Password, Password);
        }

        public override int GetHashCode()
        {
            return  Username.GetHashCode();
        }
    }
}
