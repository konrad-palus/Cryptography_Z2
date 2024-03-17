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

            string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string directoryPath = Path.Combine(userFolderPath, "x");
            string fileName = "ubuntu.iso"; 
            string outputPath = Path.Combine(directoryPath, fileName);

            Directory.CreateDirectory(directoryPath);

            Console.WriteLine("Downloading the Ubuntu image..");
            string fileUri = "https://releases.ubuntu.com/23.10.1/ubuntu-23.10.1-desktop-amd64.iso.torrent?_gl=1*72v173*_gcl_au*MTkyMzM0MTQ5OC4xNzEwNzE0MjQ3&_ga=2.210266005.1285547986.1710714240-1230512047.1710714240";
            await FilesDownloader.DownloadFileAsync(fileUri, outputPath);
            Console.WriteLine("Download completed.");

            Console.WriteLine("Hashing the downloaded file...");
            hashingExample.HashInput(outputPath); 
        }
    }
}
