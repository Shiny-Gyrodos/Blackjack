﻿using System;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Clear();
            WriteLine("Ready to play some Blackjack?\n\nPress any key to continue.");
            ReadKey();
            Clear();
            Game.Start();
            Sleep(5000);

            Clear();
            WriteLine("Care to play again? Enter 'yes' if so.");
            string playerChoice = ReadLine().ToLower() ?? "no";

            if (playerChoice == "yes")
            {
                Main();
            }
        }
    }
}