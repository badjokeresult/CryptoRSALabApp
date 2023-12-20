using System.Numerics;

namespace CryptoRSALabApp
{
    public class KeyPair
    {
        private readonly (long, long) _privateKey;
        private readonly (long, long) _publicKey;

        public KeyPair((long, long) privateKey, (long, long) publicKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
        }

        public (long, long) PrivateKey { get { return _privateKey; } }
        public (long, long) PublicKey { get {  return _publicKey; } }
    }
}
