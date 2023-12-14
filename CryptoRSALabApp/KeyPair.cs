using System.Numerics;

namespace CryptoRSALabApp
{
    public class KeyPair
    {
        private readonly (BigInteger, BigInteger) _privateKey;
        private readonly (BigInteger, BigInteger) _publicKey;

        public KeyPair((BigInteger, BigInteger) privateKey, (BigInteger, BigInteger) publicKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
        }

        public (BigInteger, BigInteger) PrivateKey { get { return _privateKey; } }
        public (BigInteger, BigInteger) PublicKey { get {  return _publicKey; } }
    }
}
