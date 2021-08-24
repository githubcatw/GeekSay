using NUnit.Framework;
using GeekSay;

namespace GeekSay.Test {
    public class WordTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void WordLove() {
            Assert.AreEqual("<3", Geek.Say("love"));
        }
        [Test]
        public void WordNot() {
            Assert.AreEqual("!", Geek.Say("not"));
        }
        [Test]
        public void WordSlow() {
            Assert.AreEqual("O(n^n)", Geek.Say("slow"));
        }
        [Test]
        public void WordSlowCaseInsensitive() {
            Assert.AreEqual("O(n^n)", Geek.Say("SlOw"));
        }
        [Test]
        public void WordLibrary() {
            Assert.AreEqual("dll", Geek.Say("library", true));
            Assert.AreEqual("library", Geek.Say("library", false));
        }
    }
}