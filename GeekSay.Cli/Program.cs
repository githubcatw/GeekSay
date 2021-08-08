using System;

namespace GeekSay.Cli {
    class Program {
        static void Main(string[] args) {
            if (args.Length > 0) Console.WriteLine(Geek.Say(args));
            else Console.WriteLine(Geek.SaySomething());
        }
    }
}
