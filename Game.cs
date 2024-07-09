class Game
{
    static void GetPlayerChoice()
    {
        string playerChoice = "to be filled";

        do
        {
            playerChoice = Console.ReadLine().ToLower() ?? "null reference";
            
        } while (playerChoice != "hit" && playerChoice != "call");
    }
}