using System.Security.Cryptography;
using System.Text;

namespace Anfx.Auth.Application.Common.Utils
{
    public class Utiles
    {
        static byte[] bytes = ASCIIEncoding.UTF8.GetBytes("Profvtv0");
        
        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("La Cadena que necesita ser encriptada puede ser nula.");
            }
            using var cryptoProvider = DES.Create();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            var writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("La Cadena que necesita ser desencriptada puede ser nula.");
            }

            using var cryptoProvider = DES.Create();
            var memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
