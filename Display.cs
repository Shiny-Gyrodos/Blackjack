abstract class Display
{
    // Dynamic object will never be used unless the dealer's hand has been instantiated, therefore the potential of throwing errors by using it is impossible.
    public static void Refresh(ref Hand playerHand, ref Hand dealerHand) 
    {
        Clear();
        WriteLine("Blackjack | HIT or CALL?");
        WriteLine(new string('-', 75));
        WriteLine($"Your total: {playerHand.Total} | Your cards: {GetCard(playerHand, 0)}     {GetCard(playerHand, 1)}     {GetCard(playerHand, 2)}     {GetCard(playerHand, 3)}     {GetCard(playerHand, 4)}");
        WriteLine(new string('-', 75));
        WriteLine($"Dealer total: {dealerHand.Total} | Dealer cards: {GetCard(dealerHand, 0)}     {GetCard(dealerHand, 1)}     {GetCard(dealerHand, 2)}     {GetCard(dealerHand, 3)}     {GetCard(dealerHand, 4)}\n{new string('-', 75)}");

        static string GetCard(Hand hand, int index) => hand.cards[index] == 0 ? " " : hand.cards[index].ToString();
    }
}