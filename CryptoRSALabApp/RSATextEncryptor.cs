using System.Numerics;
using System.Text;

namespace CryptoRSALabApp
{
    public class RSATextEncryptor
    {
        public BigInteger[] Encrypt(string message, BigInteger e, BigInteger n)
        {
            var bytes = Encoding.Unicode.GetBytes(message);
            var encrypted = new BigInteger[bytes.Length / 2];

            for (var i = 0; i < bytes.Length; i += 2)
            {
                var value = BitConverter.ToUInt16(bytes, i);
                encrypted[i / 2] = BigInteger.ModPow(value, e, n);
            }

            return encrypted;
        }

        public string ConvertToString(BigInteger[] encrypted)
        {
            var sb = new StringBuilder();
            foreach (var cipher in encrypted)
            {
                sb.Append((char)cipher);
            }
            return sb.ToString();
        }

        public string Decrypt(BigInteger[] encrypted, BigInteger d, BigInteger n)
        {
            var decryptedBytes = new byte[encrypted.Length * 2];

            for (var i = 0; i < encrypted.Length; i++)
            {
                var decryptedValue = (ushort)BigInteger.ModPow(encrypted[i], d, n);
                var decryptedBytesSegment = BitConverter.GetBytes(decryptedValue);
                Array.Copy(decryptedBytesSegment, 0, decryptedBytes, i * 2, 2);
            }

            return Encoding.Unicode.GetString(decryptedBytes);
        }
    }
}
