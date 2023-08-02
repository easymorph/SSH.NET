using System;
using System.Security.Cryptography;

using Renci.SshNet.Common;
using Renci.SshNet.Security.Cryptography.Ciphers;

namespace Renci.SshNet.Security.Cryptography
{
    /// <summary>
    /// Implements RSA digital signature algorithm sha512.
    /// SHA512 OID 2.16.840.1.101.3.4.2.3
    /// </summary>
    public class RsaSha512DigitalSignature : CipherDigitalSignature, IDisposable
    {
        private HashAlgorithm _hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaSha512DigitalSignature"/> class.
        /// </summary>
        /// <param name="rsaKey">The RSA key.</param>
        public RsaSha512DigitalSignature(RsaWithSha512SignatureKey rsaKey)
            : base(new ObjectIdentifier(2, 16, 840, 1, 101, 3, 4, 2, 3), new RsaCipher(rsaKey))
        {
            _hash = SHA512.Create();
        }

        /// <summary>
        /// Hashes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// Hashed data.
        /// </returns>
        protected override byte[] Hash(byte[] input)
        {
            return _hash.ComputeHash(input);
        }

        #region IDisposable Members

        private bool _isDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                var hash = _hash;
                if (hash != null)
                {
                    hash.Dispose();
                    _hash = null;
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RsaSha512DigitalSignature"/> is reclaimed by garbage collection.
        /// </summary>
        ~RsaSha512DigitalSignature()
        {
            Dispose(false);
        }

        #endregion
    }
}
