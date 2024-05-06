namespace EsportsProfileWebApi.Web.Helpers;

using System.Security.Cryptography;
using System.Text;

public class PasswordHashing
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return string.Empty;
        byte[] textData = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}