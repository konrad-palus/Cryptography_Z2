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
                using HashAlgorithm hashAlgorithm = HashAlgorithm.Create(algo);

                if (hashAlgorithm == null)
                {
                    Console.WriteLine($"{algo} is not available.");
                    continue;
                }

                Stopwatch stopwatch = Stopwatch.StartNew();
                byte[] hash = hashAlgorithm.ComputeHash(inputBytes);
                stopwatch.Stop();

                string hashAsString = BitConverter.ToString(hash).Replace("-", "");
                Console.WriteLine($"{algo} hash: {hashAsString}");
                //niestety w każdej konfiguracji czas hashowania u mnie wynosi 0 milisekund więc umieszczam mierzenie czasu w tickach
                Console.WriteLine($"Hashing time ticks: {stopwatch.ElapsedTicks}");

            }
        }


        public void HashFile(string filePath)
        {
            string[] algorithms = { Md5, Sha1, Sha256, Sha384, Sha512 };

            foreach (var algo in algorithms)
            {
                using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create(algo))
                {
                    if (hashAlgorithm == null)
                    {
                        Console.WriteLine($"{algo} is not available.");
                        continue;
                    }

                    using var stream = File.OpenRead(filePath);
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    byte[] hash = hashAlgorithm.ComputeHash(stream);
                    stopwatch.Stop();

                    string hashAsString = BitConverter.ToString(hash).Replace("-", "");
                    Console.WriteLine($"{algo} hash of file: {hashAsString}");
                    Console.WriteLine($"Hashing time for {algo} ticks): {stopwatch.ElapsedTicks}");
                }
            }
        }



        public void TestHashingSpeed()
        {
            int[] sizes = new int[] { 1, 10, 100, 1000, 10000, 100000 };
            foreach (int size in sizes)
            {
                byte[] data = new byte[size * 1024];
                new Random().NextBytes(data);

                using HashAlgorithm hashAlgorithm = SHA256.Create();
                Stopwatch stopwatch = Stopwatch.StartNew();
                byte[] hash = hashAlgorithm.ComputeHash(data);
                stopwatch.Stop();

                Console.WriteLine($"Hashing {size}KB of data took {stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}