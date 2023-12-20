using System.Numerics;

namespace CryptoRSALabApp
{
    public class RSAKeyGenerator
    {
        private readonly Random random = new Random();

        public KeyPair GenerateKeyPair()
        {
            var p = GeneratePrimeNumber((long)Math.Pow(2, 16));
            var q = GeneratePrimeNumber(65536);
            
            var n = p * q;
            var phi = (p - 1) * (q - 1);
            
            var e = GeneratePublicKey(phi);
            var d = GeneratePrivateKey(e, phi);

            var publicKey = (e, n);
            var privateKey = (d, n);

            return new KeyPair(publicKey, privateKey);
        }

        private long GeneratePrimeNumber(long size)
        {
            long candidate;
            do
            {
                candidate = random.NextInt64(1024, size);
            } while (!IsPrime(candidate));

            return candidate;
        }

        private bool IsPrime(long number)
        {
            if (number < 2)
                return false;

            return IsPrimeBySimpleDivs(number) && IsPrimeByErathosphene(number);
        }

        private bool IsPrimeBySimpleDivs(long number)
        {
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        private bool IsPrimeByErathosphene(long number)
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

        private long GeneratePublicKey(long phi)
        {
            var random = new Random();
            long e;

            do
            {
                e = random.Next(2, (int)phi);
            } while (Gcd(e, phi) != 1);

            return e;
        }

        private long Gcd(long a, long b)
        {
            long tmp;
            while (b != 0)
            {
                tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        private long GeneratePrivateKey(long e, long phi) => ModInverse(e, phi);

        private long ModInverse(long a, long m)
        {
            var m0 = m;
            long y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                var q = a / m;
                var t = m;

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
