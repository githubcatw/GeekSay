using System;
using System.Linq;

namespace GeekSay.Cli {
    class Program {
        static void Main(string[] args) {
            if (args.Length > 0) {
                if (args[0] == "--dos")
                    Console.WriteLine(Geek.Say(args.Skip(1).ToArray(), true));
                else
                    Console.WriteLine(Geek.Say(args));
            }
            else Console.WriteLine(Geek.SaySomething());
        }
    }
}
