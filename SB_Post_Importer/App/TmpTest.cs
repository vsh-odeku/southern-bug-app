using System;

namespace SB_Post_Importer.App
{
    public class TmpTest
    {
        public const bool Enabled = false;

        public static void Execute()
        {
            new TmpTest().Main();
        }

        public void Main()
        {
            Console.WriteLine("Hello");
        }
    }
}