using System;


using Renci.SshNet.Common;
using Renci.SshNet.Security.Cryptography;

namespace Renci.SshNet.Security
{
    /// <summary>
    /// Contains RSA private and public key (512)
    /// </summary>
    public class RsaWithSha512SignatureKey : RsaKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RsaWithSha512SignatureKey"/> class.
        /// </summary>
        public RsaWithSha512SignatureKey()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaWithSha512SignatureKey"/> class.
        /// </summary>
        /// <param name="data">DER encoded private key data.</param>
        public RsaWithSha512SignatureKey(byte[] data)
            : base(data)
        {
            if (_privateKey.Length != 8)
            {
                throw new InvalidOperationException("Invalid private key.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaWithSha512SignatureKey"/> class.
        /// </summary>
        /// <param name="modulus">The modulus.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="d">The d.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <param name="inverseQ">The inverse Q.</param>
        public RsaWithSha512SignatureKey(BigInteger modulus, BigInteger exponent, BigInteger d, BigInteger p, BigInteger q,
            BigInteger inverseQ) : base(modulus, exponent, d, p, q, inverseQ)
        {
        }

        private RsaSha512DigitalSignature _digitalSignature;

        /// <summary>
        /// Gets the digital signature.
        /// </summary>
        protected override DigitalSignature DigitalSignature
        {
            get
            {
                _digitalSignature ??= new RsaSha512DigitalSignature(this);

                return _digitalSignature;
            }
        }

        /// <summary>
        /// Gets the Key String.
        /// </summary>
        public override string ToString()
        {
            return "rsa-sha2-512";
        }
    }
}
