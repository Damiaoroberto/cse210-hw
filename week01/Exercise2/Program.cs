using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        

        int gradePercentage = int.Parse(userInput);
        string letterGrade = "";
        string gradeSign = "";

        // Determine the letter grade based on the percentage
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Determine the grade sign (+, -, or none)
        if (letterGrade != "F")
        {
            int lastDigit = gradePercentage % 10;

            if (lastDigit >= 7)
            {
                gradeSign = "+";
            }
            else if (lastDigit < 3)
            {
                gradeSign = "-";
            }
        }

        // Handle the case where A+ or F+ doesn't exist
        if (letterGrade == "A" && gradeSign == "+")
        {
            gradeSign = "-"; // No A+, so it's A-
        }
        if (letterGrade == "F")
        {
            gradeSign = ""; // No F+ or F-
        }

        string finalGrade = letterGrade + gradeSign;
        Console.WriteLine("Your letter grade is: " + finalGrade);

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the course. Keep trying!");
        }
    }
}
