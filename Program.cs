namespace Z2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Provide text:");
            Hashing hashingExample = new Hashing();

            string inputText = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputText))
            {
                hashingExample.HashInput(inputText);
            }

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "x");
            string outputPath = Path.Combine(directoryPath, "ubuntu.iso");

            Directory.CreateDirectory(directoryPath);

            Console.WriteLine("Downloading the Ubuntu image..");
            string fileUri = "https://ubuntu.com/download/desktop/thank-you?version=22.04.4&architecture=amd64";
            await FilesDownloader.DownloadFileAsync(fileUri, outputPath);
            Console.WriteLine("Download completed.");

            Console.WriteLine("Hashing the downloaded file...");
            hashingExample.HashInput(outputPath);


            Console.WriteLine("\nTesting hashing speed for different message sizes:");
            hashingExample.TestHashingSpeed();
        }
    }
}
