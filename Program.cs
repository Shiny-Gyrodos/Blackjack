using System;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Deck deck = new();
            Console.WriteLine(deck.Draw());
            Console.ReadKey();
            
            Console.WriteLine("Ready to play some Blackjack?\n\nPress any key to continue.");
            Console.Clear();
            Console.ReadKey();
        }
    }
}