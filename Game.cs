using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
static class Game
{
    private const int blackjack = 21;



    public static void Start()
    {
        Deck deck = new();
        Hand playerHand = new();
        Hand dealerHand = new();

        Display.Refresh(ref playerHand, ref dealerHand);

        while (!CheckGameEnded(playerHand.Total, dealerHand.Total))
        {
            switch (GetPlayerChoice())
            {
                case "hit":
                    Hit(ref playerHand, deck);
                    break;
                case "call":
                    Call(ref playerHand, ref dealerHand, deck);
                    break;
            }

            Display.Refresh(ref playerHand, ref dealerHand);
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

        while (dealerHand.Total < playerHand.Total)
        {
            try
            {
                Hit(ref dealerHand, deck);
            }
            catch (IndexOutOfRangeException) // Likely not the best solution, but it works.
            {
                break;
            }

            Display.Refresh(ref playerHand, ref dealerHand);
            Sleep(1000);
        }
    }



    private static void Hit(ref Hand hand, Deck deck)
    {
        int cardDrawn = deck.Draw();
        hand.AddCard(cardDrawn == 11 && hand.Total + 11 > blackjack ? cardDrawn - 10 : cardDrawn);
    }



    // Ugly, but I can't think of a better solution.
    static bool CheckGameEnded(int playerTotal, int dealerTotal)
    {
        #region Win Conditions

        if (playerTotal == blackjack)
        {
            WriteLine("\nYOU WIN! You got 21 exactly.");
            return true;
        }
        if (playerTotal < blackjack && playerTotal > dealerTotal)
        {
            WriteLine("\nYOU WIN! Dealer total is less and reached card limit.");
            return true;
        }
        if (dealerTotal > blackjack)
        {
            WriteLine("\nYOU WIN! Dealer busted.");
            return true;
        }

        #endregion

        #region Lose Conditions

        if (playerTotal > blackjack)
        {
            WriteLine("\nYOU LOSE. You busted!");
            return true;
        }
        if (dealerTotal <= blackjack && dealerTotal > playerTotal)
        {
            WriteLine("\nYOU LOSE. Dealer is closer!");
            return true;
        }

        #endregion

        // Draw condition (rare)
        if (playerTotal < blackjack && playerTotal == dealerTotal)
        {
            WriteLine("DRAW. You and the dealer have the same total.");
            return true;
        }

        return false;
    }
}