using System;
using System.Collections.Generic;
using System.Text;

namespace Opd
{
    public class OpdAPI
    {
        public bool ProfanityDetected(string _phrase)
        {
            string Phrase = _phrase;
            Phrase = RemoveCleanWordsThatContainProfanity(_phrase);
            return false;
        }

        private string RemoveCleanWordsThatContainProfanity(string _phrase)
        {
            return "";
        }
    }
}
