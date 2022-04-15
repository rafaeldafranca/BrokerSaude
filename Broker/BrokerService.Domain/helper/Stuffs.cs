using System.Security.Cryptography;
using System.Text;

namespace BrokerService.Domain.helper
{
    public static class Stuffs
    {
        public static string GetHashDB(this string value)
        {
            var salt = "!@#$";
            HashAlgorithm _algorithm = MD5.Create();
            var encodedValue = Encoding.UTF8.GetBytes(value + salt);
            var encryptedPassword = _algorithm.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string alfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
