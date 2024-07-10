using System.Reflection.Metadata;
struct Hand()
{
    private int index = 0;
    private int[] cards = new int[5];
    public int Total => cards.Sum();
    public void AddCard(int value) => cards[index++] = value;
}



class Game
{
    private const int blackjack = 21;


    static string GetPlayerChoice()
    {
        string playerChoice = "";

        while (playerChoice != "hit" && playerChoice != "call")
        {
            playerChoice = Console.ReadLine().ToLower() ?? "null reference";
        }

        return playerChoice;
    }



    static void Call(Hand playerHand, Deck deck)
    {
        Console.WriteLine("The dealer will now draw cards.");
        Hand dealerHand = new();
        string message = "YOU LOSE. Dealer is closer.";

        while (dealerHand.Total < playerHand.Total)
        {
            try
            {
                Console.Write(Hit(dealerHand, deck) + " ");
            }
            catch (IndexOutOfRangeException)
            {
                message = "YOU WIN! Dealer busts.";
                break;
            }
        }

        Console.WriteLine(message);
    }



    static int Hit(Hand hand, Deck deck)
    {
        int cardDrawn = deck.Draw();
        hand.AddCard(cardDrawn == 11 && hand.Total + 11 > blackjack ? cardDrawn - 10 : cardDrawn);
        return cardDrawn;
    }
}