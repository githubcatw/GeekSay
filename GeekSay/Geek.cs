using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeekSay {
    public static class Geek {

        private static readonly Regex numRE = new Regex("/(?!\n|\r\n)[^a-zA-Z0-9]+/");

        /// <summary>
        /// Convert something from layman text to geek text.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="dos">Whether to enable extra Windows/DOS related translations.</param>
        public static string Say(string text, bool dos = false) => Say(text.Split(' '), dos);

        /// <summary>
        /// Convert something from layman text to geek text.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="dos">Whether to enable extra Windows/DOS related translations.</param>
        public static string Say(string[] text, bool dos = false) {
            var geekized = text.Select(e => SayWord(e, dos)).ToArray();
            return string.Join(" ",geekized);
        }

        /// <summary>
        /// Convert a word from layman text to geek text.
        /// </summary>
        /// <param name="word">The word to convert.</param>
        /// <param name="dos">Whether to enable extra Windows/DOS related translations.</param>
        public static string SayWord(string word, bool dos = false) {
            int wordNum;
            if (int.TryParse(word, out wordNum)) {
                return Convert.ToString(wordNum, 2);
            } else {
                string lowerWord = numRE.Replace(word, "").ToLower();
                if (GeekWords.conversions.ContainsKey(lowerWord)) {
                    word = word.Replace(word, GeekWords.conversions[lowerWord]);
                }
                else if (dos && GeekWords.winwords.ContainsKey(lowerWord)) {
                    word = word.Replace(word, GeekWords.winwords[lowerWord]);
                }
                return word;
            }
        }

        /// <summary>
        /// Say a random word in layman and geek.
        /// </summary>
        /// <returns> A string in this format: <br/>Random translation: [layman word] -> [geek word]</returns>
        /// <param name="dos">Whether to enable extra Windows/DOS related translations.</param>
        public static string SaySomething(bool dos = false) {
            var words = GeekWords.conversions;
            if (dos) words = words.Concat(GeekWords.winwords).ToDictionary(k => k.Key, v => v.Value);
            int index = new Random().Next(words.Keys.Count);
            var rndWord = words.ElementAt(index);
            return $"Random translation: {rndWord.Key} -> {rndWord.Value}";
        }
    }
}
