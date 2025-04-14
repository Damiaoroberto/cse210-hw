//add  Exceeding Requirements
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
      
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John 3:16"), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs 3:5-6"), "Trust in the Lord with all your heart, and lean not on your own understanding. In all your ways acknowledge him, and he shall direct your paths."),
            new Scripture(new Reference("Psalm 23:1"), "The Lord is my shepherd; I shall not want."),
            
        };

        // Randomly select a scripture
        Random rand = new Random();
        var selectedScripture = scriptures[rand.Next(scriptures.Count)];

        Console.WriteLine($"Now memorizing: {selectedScripture.GetReference()}\n");

        // Loop to allow the user to memorize the scripture
        while (true)
        {
            Console.Clear();
            selectedScripture.DisplayScripture();
            Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to exit.");
            var userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWord();
        }

        Console.WriteLine("All words are hidden. Exiting...");
    }
}
