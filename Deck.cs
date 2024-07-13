using System.Collections.Immutable;

class Deck
{
    public int Draw() => deck.Pop();



    private Stack<int> deck = [];



    public Deck()
    {
        for (int i = 2; i <= 11; i++)
        {
            if (i == 10)
            {
                deck.PushRange(i, i, i, i, i, i, i, i, i, i, i, i, i, i, i, i);
            }
            else
            {   
                deck.PushRange(i, i, i, i);
            }
        }

        deck.Shuffle();
    }
}