using System;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Hand playerHand = new();
            playerHand.AddCard(1);
            playerHand.AddCard(2);
            playerHand.AddCard(3);
            playerHand.AddCard(4);
            playerHand.AddCard(5);
            foreach (int card in playerHand.cards)
            {
                Write(card + " ");
            }
            Write(playerHand.Total);
            ReadKey();

            Deck deck = new();

            Clear();
            WriteLine("Ready to play some Blackjack?\n\nPress any key to continue.");
            ReadKey();
            Clear();
            Game.Start(deck);
            Sleep(5000);
            Clear();
            WriteLine("Care to play again? YES - NO");

            if (ReadLine().ToLower() == "yes")
            {
                Main();
            }
        }
    }
}