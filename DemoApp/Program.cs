using System;
using Microsoft.Owin.Hosting;

namespace DemoApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("Server is running...");
                Console.WriteLine("Plain HTML: http://localhost:12345/test");
                Console.WriteLine("WebApi:     http://localhost:12345/api");
                Console.WriteLine("Nancy:      http://localhost:12345/site");
                Console.WriteLine("Nancy:      http://localhost:12345/site/hello");
                Console.ReadLine();
            }
        }
    }
}