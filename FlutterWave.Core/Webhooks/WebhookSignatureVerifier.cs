using System.Security.Cryptography;
using System.Text;

namespace FlutterWave.Core.Webhooks
{
    public static class WebhookSignatureVerifier
    {
        public static bool IsValid(string secretHash, string verifHashHeaderValue)
        {
            if (string.IsNullOrEmpty(secretHash) || string.IsNullOrEmpty(verifHashHeaderValue))
            {
                return false;
            }

            byte[] expectedBytes = Encoding.UTF8.GetBytes(secretHash);
            byte[] actualBytes = Encoding.UTF8.GetBytes(verifHashHeaderValue);

            if (expectedBytes.Length != actualBytes.Length)
            {
                return false;
            }

            return CryptographicOperations.FixedTimeEquals(expectedBytes, actualBytes);
        }
    }
}
