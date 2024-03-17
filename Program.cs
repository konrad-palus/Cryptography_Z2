namespace Z2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide text");
            Hashing hashingExample = new Hashing();

            hashingExample.HashInput(Console.ReadLine()!);
        }
    }
}
