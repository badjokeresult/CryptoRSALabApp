using System.Numerics;
using System.Text;

namespace CryptoRSALabApp
{
    public class RSATextEncryptor
    {
        public string Encrypt(string message, BigInteger e, BigInteger n)
        {
            var bytes = Encoding.Unicode.GetBytes(message);
            var encrypted = new BigInteger[bytes.Length / 2];

            for (var i = 0; i < bytes.Length; i += 2)
            {
                var value = BitConverter.ToUInt16(bytes, i);
                encrypted[i / 2] = BigInteger.ModPow(value, e, n);
            }

            return ConvertToString(encrypted);
        }

        private string ConvertToString(BigInteger[] encrypted)
        {
            var sb = new StringBuilder();
            foreach (var cipher in encrypted)
            {
                sb.Append((char)(ushort)cipher);
            }
            return sb.ToString();
        }

        public string Decrypt(string encrypted, BigInteger d, BigInteger n)
        {
            var encryptedArray = ConvertToBigIntegerArray(encrypted);

            var decryptedBytes = new byte[encryptedArray.Length * 2];

            for (var i = 0; i < encryptedArray.Length; i++)
            {
                var decryptedValue = (ushort)BigInteger.ModPow(encryptedArray[i], d, n);
                var decryptedBytesSegment = BitConverter.GetBytes(decryptedValue);
                Array.Copy(decryptedBytesSegment, 0, decryptedBytes, i * 2, 2);
            }

            return Encoding.Unicode.GetString(decryptedBytes);
        }

        private BigInteger[] ConvertToBigIntegerArray(string decrypted)
        {
            var bytes = Encoding.Unicode.GetBytes(decrypted);
            var result = new BigInteger[bytes.Length / 2];

            for (var i = 0; i <  bytes.Length; i += 2)
            {
                var val = BitConverter.ToUInt16(bytes, i);
                result[i / 2] = val;
            }

            return result;
        }
    }
}
