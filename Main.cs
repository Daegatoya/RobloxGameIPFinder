using RobloxIPFinder;

namespace RobloxIPFinder
{
    public static class Class
    {
        public static void Main()
        {
            string _dir = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "Roblox\\logs");
            string? IP;
            FileReader reader = new FileReader(_dir, null);

            IP = reader.ReturnIP();

            Console.WriteLine(IP);
        }
    }
}
