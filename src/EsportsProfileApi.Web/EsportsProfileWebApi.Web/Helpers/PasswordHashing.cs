namespace EsportsProfileWebApi.Web.Helpers;

using System.Security.Cryptography;
using System.Text;

public class PasswordHashing
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return string.Empty;

        using (var sha = SHA256.Create())
        {
            byte[] textData = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return HashPassword(password) == hashedPassword;
    }
}