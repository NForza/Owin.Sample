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
                Console.ReadLine();
            }
        }
    }
}