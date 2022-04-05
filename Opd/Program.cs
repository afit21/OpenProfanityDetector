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
            //api.ProfanityDetected(args[0]);
            Console.WriteLine(api.ProfanityDetected("Potato, Therapist, When a person learns to write English sentences and compositions, one common problem is writing sentences that are too long. When a sentence ends too quickly, it is called a sentence fragment. When a sentence has too many ideas and runs on too long, it is called a run-on sentence"));
            Console.ReadKey();
        }
    }
}
