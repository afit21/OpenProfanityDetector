using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opd
{
    public class OpdAPI
    {
        Wordlists wordlists = new Wordlists();
        public bool ProfanityDetected(string _phrase)
        {
            //Defines lists
            List<string> profanity = wordlists.ProfanityWords;
            List<string> clean = wordlists.CleanWords;
            List<string> substituteProfanity = SubstituteCharacters(profanity);

            //Formats the phase to be processed
            string Phrase = _phrase.ToLower();
            Phrase = Phrase.Replace(" ", "");
            Phrase = Phrase.Replace(",", "");
            Phrase = Phrase.Replace(".", "");
            Phrase = Phrase.Replace(".", "");
            Phrase = Phrase.Replace(@"\", "");

            //Removes words that are clean, but may be detected as hidden profanity (eg, Niger or Therapist)
            Phrase = RemoveWordsInList(Phrase, clean);

            //Checks for profanity
            if (lookForWordsInList(Phrase, profanity))
                return true;
            if (lookForWordsInList(Phrase, substituteProfanity))
                return true;

            return false;
        }

        //Removes words in a list from a string
        private string RemoveWordsInList(string _phrase, List<string> _list)
        {
            string returnString = _phrase;
            foreach(string word in _list)
            {
                returnString = returnString.Replace(word, "");
            }
            return returnString;
        }

        //Returns true if a string contains a string from a given list
        private bool lookForWordsInList(string _phrase, List<string> _list)
        {
            var returnbool = false;
            Parallel.ForEach(_list, (word, state) =>
            {
                if (_phrase.Contains(word))
                {
                    returnbool = true;
                    state.Break();
                }
            });
            return returnbool;
        }

        //Returns a a list based on a list provided which contains common substitutions to characters in the list. (eg, crap > cr@p)
        private List<string> SubstituteCharacters(List<string> _list)
        {
            ConcurrentBag<string> returnList = new ConcurrentBag<string>();

            Parallel.ForEach(_list, word =>
            {
                bool containsA = word.Contains("a");
                bool containsS = word.Contains("s");

                if (containsA)
                    returnList.Add(word.Replace('a', '@'));

                if (containsS)
                    returnList.Add(word.Replace('s', '$'));

                if (containsA && containsS)
                    returnList.Add(word.Replace('s', '$').Replace('a', '@'));
            });

            return returnList.ToList();
        }
    }
}
