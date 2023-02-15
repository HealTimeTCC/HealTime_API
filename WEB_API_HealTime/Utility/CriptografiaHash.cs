using System.Security.Cryptography;

namespace WEB_API_HealTime.Utility;

static public class CriptografiaHash
{
    public static void CriptografiaSenhaHash(string senha, out byte[] hash, out byte[] salt)
    {
        using (var hmac = new HMACSHA512())
        {
            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }
    }
}
