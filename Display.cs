abstract class Display
{
    static void Refresh(Hand hand, bool gameCalled)
    {
        Clear();
        WriteLine(gameCalled ? "Blackjack |" : "Blackjack | HIT or CALL?");
        Spaces();
        WriteLine($"Your total: {hand.Total} | Your cards: {GetCard(hand, 0)}     {GetCard(hand, 1)}     {GetCard(hand, 2)}     {GetCard(hand, 3)}     {GetCard(hand, 4)}");
        Spaces();
        WriteLine(gameCalled ? $"Dealer total: {hand.Total} | Dealer cards: {GetCard(hand, 0)}     {GetCard(hand, 1)}     {GetCard(hand, 2)}     {GetCard(hand, 3)}     {GetCard(hand, 4)}\n{new string('-', 20)}" : "");

        static string GetCard(Hand hand, int index) => hand.cards[index] == 0 ? " " : hand.cards[index].ToString();
        static void Spaces() => WriteLine(new string('-', 20));
    }
}