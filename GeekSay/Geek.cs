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
        public static string Say(string text) => Say(text.Split(' '));

        /// <summary>
        /// Convert something from layman text to geek text.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        public static string Say(string[] text) {
            var geekized = text.Select(e => SayWord(e)).ToArray();
            return string.Join(" ",geekized);
        }

        /// <summary>
        /// Convert a word from layman text to geek text.
        /// </summary>
        /// <param name="word">The word to convert.</param>
        public static string SayWord(string word) {
            int wordNum;
            if (int.TryParse(word, out wordNum)) {
                return Convert.ToString(wordNum, 2);
            } else {
                string lowerWord = numRE.Replace(word, "");
                if (GeekWords.conversions.ContainsKey(lowerWord)) {
                    word = word.Replace(word, GeekWords.conversions[lowerWord]);
                }
                return word;
            }
        }

        /// <summary>
        /// Say a random word in layman and geek.
        /// </summary>
        /// <returns> A string in this format: <br/>Random translation: [layman word] -> [geek word]</returns>
        public static string SaySomething() {
            int index = new Random().Next(GeekWords.conversions.Keys.Count);
            var rndWord = GeekWords.conversions.ElementAt(index);
            return $"Random translation: {rndWord.Key} -> {rndWord.Value}";
        }
    }
}
