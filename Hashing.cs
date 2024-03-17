using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Z2
{
    public class Hashing
    {
        private const string Md5 = "MD5";
        private const string Sha1 = "SHA1";
        private const string Sha256 = "SHA256";
        private const string Sha384 = "SHA384";
        private const string Sha512 = "SHA512";

        public void HashInput(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string[] algorithms = { Md5, Sha1, Sha256, Sha384, Sha512 };

            foreach (var algo in algorithms)
            {
                HashAlgorithm hashAlgorithm = HashAlgorithm.Create(algo);

                if (hashAlgorithm == null)
                {
                    Console.WriteLine($"{algo} is not avaliable.");
                    continue;
                }

                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Stop();

                Console.WriteLine($"{algo} hash: {BitConverter.ToString(hashAlgorithm.ComputeHash(inputBytes)).Replace("-", "")}");
                Console.WriteLine($"Czas hashowania (ms): {stopwatch.ElapsedMilliseconds}");
            }
        }
    }
}