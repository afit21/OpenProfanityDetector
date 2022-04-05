using System;
using System.Collections.Generic;
using System.Text;

namespace Opd
{
    class Program
    {
        public static OpdAPI api = new OpdAPI();
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            //api.ProfanityDetected(args[0]);
            Console.WriteLine(api.ProfanityDetected(Console.ReadLine()));
            Main(new string[1]);
        }
    }
}
