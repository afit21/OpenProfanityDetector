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
            Console.WriteLine(api.ProfanityDetected(args[0]));
        }
    }
}
