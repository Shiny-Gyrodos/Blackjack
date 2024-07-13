using System.Collections.Immutable;

class Deck
{
    public int Draw() => deck.Pop();



    private Stack<int> deck = [];



    public Deck()
    {
        for (int i = 1; i <= 11; i++)
        {
            if (i == 10)
            {
                deck.PushRange([i, i, i, i, i, i, i, i, i, i, i, i, i, i, i, i]);
            }
            else
            {   
                deck.PushRange([i, i, i, i]);
            }
        }

        deck.Shuffle();
    }
}



static class StackExtensions // Contained extension methods generic because why not.
{
    private static readonly Random rng = new();



    public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> valuesToAdd)
    {
        foreach (T value in valuesToAdd)
        {
            stack.Push(value);
        }
    }


    public static Stack<T> Shuffle<T>(this Stack<T> stack)
    {
        T[] array = [.. stack];
        rng.Shuffle(array);
        stack.Clear();

        foreach (T item in array)
        {
            stack.Push(item);
        }

        return stack;
    }
}