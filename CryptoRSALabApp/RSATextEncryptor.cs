using System;
using System.Numerics;
using System.Text;

namespace CryptoRSALabApp
{
    public class RSATextEncryptor
    {
        private static long ModPow(long baseValue, long exponent, long modulus)
        {
            long result = 1;
            while (exponent > 0)
            {
                if (exponent % 2 == 1)
                {
                    result = (result * baseValue) % modulus;
                }
                exponent >>= 1;
                baseValue = (baseValue * baseValue) % modulus;
            }
            return result;
        }

        public string Encrypt(string message, long e, long n)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            var encryptedValues = new long[bytes.Length];

            for (var i = 0; i < bytes.Length; i++)
            {
                int value = bytes[i];
                encryptedValues[i] = ModPow(value, e, n);
            }

            var base64String = Convert.ToBase64String(BitConverter.GetBytes(encryptedValues.Length)
                .Concat(encryptedValues.SelectMany(BitConverter.GetBytes))
                .ToArray());
            return base64String;
        }

        public string Decrypt(string encrypted, long d, long n)
        {
            var encryptedBytes = Convert.FromBase64String(encrypted);
            var length = BitConverter.ToInt32(encryptedBytes, 0);
            var encryptedValues = new long[length];

            Buffer.BlockCopy(encryptedBytes, sizeof(int), encryptedValues, 0, encryptedBytes.Length - sizeof(int));

            var decryptedBytes = new byte[encryptedValues.Length];

            for (var i = 0; i < decryptedBytes.Length; i++)
            {
                int decryptedValue = (int)ModPow(encryptedValues[i], d, n);
                decryptedBytes[i] = (byte)decryptedValue;
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }

}
