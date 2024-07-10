using System.Collections.Immutable;

class Deck
{
    private static readonly Random rng = new();
    private readonly List<int> allCards = [];
    private Stack<int> deck = [];



    public int Draw() => deck.Pop();
    public int Peek() => deck.Peek();



    private static void ShuffleCardsIntoDeck(List<int> allCards, Stack<int> deck)
    {
        for (int i = 0; i < allCards.Count; i++)
        {
            int tempCard = allCards[rng.Next(0, allCards.Count)];
            allCards.Remove(tempCard);
            deck.Push(tempCard);
        }
    }


    public Deck()
    {
        for (int i = 1; i <= 11; i++)
        {
            if (i == 10)
            {
                allCards.AddRange([i, i, i, i, i, i, i, i, i, i, i, i, i, i, i, i]);
            }
            else
            {   
                allCards.AddRange([i, i, i, i]);
            }
        }

        ShuffleCardsIntoDeck(allCards, deck);
    }
}