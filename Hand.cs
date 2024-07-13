struct Hand()
{
    private int index = 0;
    public int[] cards = new int[5];
    public int Total => cards.Sum();
    public void AddCard(int value) => cards[index++] = value;
}