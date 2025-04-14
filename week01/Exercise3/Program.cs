using System;

class GuessMyNumber
{
    static void Main()
    {
        bool playAgain = true;  

        while (playAgain)
        {
           
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); 

            int guess = 0;
            int guessCount = 0;

           
            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I have picked a magic number between 1 and 100. Try to guess it!");

           
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                bool isValid = int.TryParse(Console.ReadLine(), out guess);

                if (!isValid)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                guessCount++;  

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes"; 
        }

        
        Console.WriteLine("Thank you for playing!");
    }
}
