using Pirsch.DotNet.SDK;
using System;

namespace UWPConsole
{
    class Program
    {
        static string GetRandomIpAddress()
        {
            var random = new Random();
            return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Try PirschCSharpSDK (UWP)");
            Console.WriteLine("For .NET Standard 2.0");

            // Init
            Client client = new Client(new ClientConfig("<client_id>", "<client_secret>"));

            // Hit with minimum entries
            Hit newHit = new Hit();
            newHit.Url = "/index";
            newHit.Ip = GetRandomIpAddress(); // You can generate a random Ip Address and save it locally like an identifier
            newHit.User_agent = "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/87.0.4280.77 Mobile/15E148 Safari/604.1";

            // Sync
            // In Async mode, Exception is ignore
            try
            {
                client.Hit(newHit).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Hit send!");
            Console.ReadKey();
        }
    }
}
