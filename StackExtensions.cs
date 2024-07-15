static class StackExtensions // Contained extension methods are generic because why not.
{
    private static readonly Random rng = new();



    public static void PushRange<T>(this Stack<T> stack, params T[] valuesToAdd)
    {
        foreach (T value in valuesToAdd)
        {
            stack.Push(value);
        }
    }


    public static void Shuffle<T>(this Stack<T> stack)
    {
        T[] array = [.. stack];
        rng.Shuffle(array);
        stack = new(array);
    }
}