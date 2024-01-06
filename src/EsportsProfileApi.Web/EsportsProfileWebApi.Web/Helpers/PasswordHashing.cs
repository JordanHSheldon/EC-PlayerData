namespace EsportsProfileWebApi.Web.Helpers;

using System.Security.Cryptography;
using System.Text;

public class PasswordHashing
{
    public static string HashPassword(string password)
    {
        if (String.IsNullOrEmpty(password))
            return String.Empty;

        using (var sha = new SHA256Managed())
        {
            byte[] textData = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return HashPassword(password) == hashedPassword;
    }
}