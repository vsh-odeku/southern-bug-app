using NUnitLite;
using System;

namespace NUnitLite.Tests
{
    public class Program
    {
        public static int Main(string[] args)
        {
            int ret = new AutoRun().Execute(args);

            if (ret == 0)
            {
                Console.WriteLine("\nAll is fine! Ending in 3 seconds...");
                System.Threading.Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("\nTest failed. Press any key to continue...");
                Console.ReadKey(true);
            }

            return ret;
        }
    }
}