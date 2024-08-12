using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace VoltApi.Extentions
{
    public static partial class StringExtensions
    {
        private const string Pattern = @"[^a-zA-Z0-9 !@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]+";

        public static byte[] GetHash(string inputString)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(this string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [GeneratedRegex("[^a-zA-Z0-9 !@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]+")]
        private static partial Regex ClearRegex();

        public static string CleanString(this string input)
        {
            var cleanedString = ClearRegex().Replace(input, string.Empty);
            return cleanedString;
        }

        public static string GenerateKey(this string sourceString)
        {
            var separator = "-";
            int[] lengths = {20, 12, 12, 20}; 

            var parts = new List<string>();
            var startIndex = 0;

            foreach (var length in lengths)
            {
                var part = sourceString.Substring(startIndex, length);
                parts.Add(part);
                startIndex += length;
            }

            var result = string.Join(separator, parts);

            return result;
        }
    }
}
