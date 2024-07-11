using System;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Deck deck = new();
            WriteLine(deck.Draw());
            ReadKey();
            
            WriteLine("Ready to play some Blackjack?\n\nPress any key to continue.");
            Clear();
            ReadKey();
        }
    }
}