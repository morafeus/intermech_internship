using System.Security.Cryptography;
using System.Text;

namespace WebAPI_internship
{
    public static class HashService
    {
        private const int KEYSIZE = 64;
        private const int ITERATIONS = 10000;
        private static HashAlgorithmName HASHALGORITM = HashAlgorithmName.SHA256;

        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(KEYSIZE);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
               Encoding.UTF8.GetBytes(password),
               salt,
               ITERATIONS,
               HASHALGORITM,
               KEYSIZE);

            var hashBytes = new byte[KEYSIZE + KEYSIZE];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, KEYSIZE);
            Buffer.BlockCopy(hash, 0, hashBytes, KEYSIZE, KEYSIZE);

            return Convert.ToBase64String(hashBytes);

        }

        public static bool VerifyPassword(string password, string hash)
        {
            byte[] hashBytes;
            try
            {
                hashBytes = Convert.FromBase64String(hash);
            }
            catch
            {
                return false;
            }

            var salt = new byte[KEYSIZE];
            var storedHash = new byte[KEYSIZE];

            Buffer.BlockCopy(hashBytes, 0, salt, 0, KEYSIZE);
            Buffer.BlockCopy(hashBytes, KEYSIZE, storedHash, 0, KEYSIZE);

            var calculatedHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                ITERATIONS,
                HASHALGORITM,
                KEYSIZE);

            return CryptographicOperations.FixedTimeEquals(calculatedHash, storedHash);
        }
    }
}
