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


    public static void Shuffle<T>(this Stack<T> stack)
    {
        T[] array = [.. stack];
        rng.Shuffle(array);
        stack.Clear();

        foreach (T item in array)
        {
            stack.Push(item);
        }
    }
}