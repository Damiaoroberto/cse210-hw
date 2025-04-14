using System;

class Program
{
  
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

 
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }


    static int SquareNumber(int number)
    {
        return number * number;
    }


    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }

    static void Main(string[] args)
    {
     
        DisplayWelcome(); 
        
        string name = PromptUserName(); 
        int favoriteNumber = PromptUserNumber();  
        
        int squaredNumber = SquareNumber(favoriteNumber);  
        
        DisplayResult(name, squaredNumber);
    }
}
