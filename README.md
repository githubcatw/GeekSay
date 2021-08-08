# GeekSay
> geeks will ctrl+s the world

A port of the npm package [geeksay](https://github.com/swapagarwal/geeksay) to C#/.NET Standard.

## Installation

It's available on NuGet as [GeekSay](https://www.nuget.org/packages/GeekSay).

## Usage

### CLI

Without arguments it generates a random quote.

```
$p$g>geeksay-cli to be or not to be, that is the question
to be || ! to be, that is the ?

$p$g>geeksay-cli please make me a sandwich
sudo make self a sandwich

$p$g>geeksay-cli
Random translation: send -> push
```

### Library
```c#
Geek.Say("there is no place like home"); // there is no place like 127.0.0.1
Geek.SaySomething(); // Random translation: smile -> :)
Geek.SayWord("white"); // #fff
```
