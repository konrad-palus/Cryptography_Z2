namespace Z2
{
    public class FilesDownloader
    {
        public static async Task DownloadFileAsync(string fileUri, string outputPath)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(fileUri, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
            await stream.CopyToAsync(fileStream);
        }
    }
}