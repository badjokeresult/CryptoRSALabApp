using System.Numerics;

namespace CryptoRSALabApp
{
    public class RSAKeyGenerator
    {
        public KeyPair GenerateKeyPair()
        {
            var p = GeneratePrimeNumber(4096);
            var q = GeneratePrimeNumber(4096);
            
            var n = p * q;
            var phi = (p - 1) * (q - 1);
            
            var e = GeneratePublicKey(phi);
            var d = GeneratePrivateKey(e, phi);

            var publicKey = (e, n);
            var privateKey = (d, n);

            return new KeyPair(publicKey, privateKey);
        }

        private BigInteger GeneratePrimeNumber(int size)
        {
            var random = new Random();
            int candidate = random.Next(1024, size);

            while (!IsPrime(candidate))
                candidate = random.Next(100, 200);

            return candidate;
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            return IsPrimeBySimpleDivs(number) && IsPrimeByErathosphene(number);
        }

        private bool IsPrimeBySimpleDivs(int number)
        {
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        private bool IsPrimeByErathosphene(int number)
        {
            var numbersPrimarityStatuses = new bool[number + 1];
            Array.Fill(numbersPrimarityStatuses, true);

            for (var i = 2; i * i <= number; i++)
            {
                if (numbersPrimarityStatuses[i])
                {
                    for (var j = i * i; j <= number; j += i)
                    {
                        numbersPrimarityStatuses[j] = false;
                    }
                }
            }

            return numbersPrimarityStatuses[number];
        }

        private BigInteger GeneratePublicKey(BigInteger phi)
        {
            var random = new Random();
            BigInteger e;

            do
            {
                e = random.Next(2, (int)phi);
            } while (BigInteger.GreatestCommonDivisor(e, phi) != 1);

            return e;
        }

        private BigInteger GeneratePrivateKey(BigInteger e, BigInteger phi) => ModInverse(e, phi);

        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            var m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }
    }
}
