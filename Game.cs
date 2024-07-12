using System.Reflection.Metadata;
using System.Security.Cryptography;
struct Hand()
{
    private int index = 0;
    public int[] cards = new int[5];
    public int Total => cards.Sum();
    public void AddCard(int value) => cards[index++] = value;
}



class Game
{
    private const int blackjack = 21;



    public static void Start(Deck deck)
    {
        Hand playerHand = new();
        Hand dealerHand = new();

        while (playerHand.cards[4] == 0) // Needs new condition
        {
            Display.Refresh(ref playerHand, ref dealerHand);

            switch (GetPlayerChoice())
            {
                case "hit":
                    Hit(ref playerHand, deck);
                    if (playerHand.cards[4] != 0 && playerHand.Total < 21) Call(ref playerHand, ref dealerHand, deck);
                    break;
                case "call":
                    Call(ref playerHand, ref dealerHand, deck);
                    break;
            }

            if (playerHand.Total >= blackjack) WriteLine("YOU LOSE. You went over 21!");
            else if (playerHand.Total == blackjack) WriteLine("YOU WIN! You got to 21 exactly!");
        }
    }



    private static string GetPlayerChoice()
    {
        string playerChoice = "";

        while (playerChoice != "hit" && playerChoice != "call")
        {
            playerChoice = ReadLine().ToLower() ?? "null reference";
        }

        return playerChoice;
    }



    private static void Call(ref Hand playerHand, ref Hand dealerHand, Deck deck)
    {
        WriteLine("\nThe dealer will now draw cards.");
        Sleep(3000);
        Display.Refresh(ref playerHand, ref dealerHand);
        string message = "YOU LOSE. Dealer is closer.";

        while (dealerHand.Total < playerHand.Total)
        {
            try
            {
                Hit(ref dealerHand, deck, true);
            }
            catch (IndexOutOfRangeException)
            {
                message = "YOU WIN! Dealer drew five cards and is lower.";
                break;
            }

            Display.Refresh(ref playerHand, ref dealerHand);
            Sleep(1000);
        }

        message = dealerHand.Total > blackjack ? "YOU WIN! Dealer busts." : message;
        WriteLine("\n" + message);
    }



    // Returns the card drawn for display.
    private static int Hit(ref Hand hand, Deck deck, bool gameCalled = false)
    {
        int cardDrawn = deck.Draw();
        hand.AddCard(cardDrawn == 11 && hand.Total + 11 > blackjack ? cardDrawn - 10 : cardDrawn);
        return cardDrawn;
    }
}