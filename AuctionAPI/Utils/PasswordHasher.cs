using System.Security.Cryptography;

namespace AuctionAPI.Utils
{
    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Pbkdf2Iterations = 1000;
        private const string Delimiter = ":";

        public static string HashPassword(string password)
        {
            var salt = new byte[SaltSize];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(salt);
            }

            var hash = Pbkdf2(password, salt, Pbkdf2Iterations, HashSize);
            return Pbkdf2Iterations + Delimiter +
                   Convert.ToBase64String(salt) + Delimiter +
                   Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            char[] delimiter = Delimiter.ToCharArray();
            var split = correctHash.Split(delimiter);
            var iterations = int.Parse(split[0]);
            var salt = Convert.FromBase64String(split[1]);
            var hash = Convert.FromBase64String(split[2]);

            var testHash = Pbkdf2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt) { IterationCount = iterations };
            return pbkdf2.GetBytes(outputBytes);
        }
        
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}
