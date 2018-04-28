using System;

// Namespace
namespace NumberGuesser
{
    // Main Class
    class Program
    {
        // Entry Point Method
        // <Access Specifier> <Return Type> <Method Name>(Parameter List)
        static void Main(string[] args)
        {
            //string name = "Johnny";
            //int age = 24;
            //Console.WriteLine("My name is {0} and my age is {1}", name, age);

            DisplayAppInfo();

            WelcomeUser();

            // Create a new random object
            Random random = new Random();

            // Init correct number
            int minValue = 0;
            int maxValue = 20;
            int correctNumber = random.Next(minValue, maxValue);
            Console.WriteLine(correctNumber);

            // Init guess var
            //int guess = 0;

            // While guess is not correct
            //while(guess != correctNumber){
            while (true){
                
                // Ask user for number
                Console.Write("Guess a number between {0} and {1}: ", minValue, maxValue);

                // Get user input
                string input = Console.ReadLine();

                // Validate user input
                bool validGuess = ValidateGuess(input);
                if (!validGuess)
                {
                    PrintColorMsg(color: ConsoleColor.Red, msg: "Please enter an actual number.");
                    continue;
                }

                // Cast to int and put in guess
                int guess = Int32.Parse(input);

                // Compare guess to correct number
                if (guess < minValue || guess > maxValue){
                    // Incorrect guess: outside bounds
                    PrintColorMsg(ConsoleColor.Red, "Number outside the min and max bounds, please try again.");
                } else if (guess < correctNumber) {  // minValue <= guess < correctNumber
                    // Incorrect guess: too low
                    PrintColorMsg(ConsoleColor.Red, "Number is too low, please try again.");
                } else if (guess > correctNumber) {
                    // Incorrect guess: too high
                    PrintColorMsg(ConsoleColor.Red, "Number is too high, please try again.");
                } else if (guess == correctNumber) {
                    // Correct guess: exit loop
                    PrintColorMsg(ConsoleColor.Green, "Congrats, you are correct!!!");
                    break;
                } else {
                    PrintColorMsg(ConsoleColor.Cyan, "Something went terribly wrong.");
                    break;
                }
            }
        }

        // Helper methods
        static void DisplayAppInfo(){
            // Set app vars
            string appName = "Number Guesser";
            string appVersion = "0.1.0";
            string appAuthor = "Johnny Metz";
            string infoString = appName + ": Version " + appVersion + " by " + appAuthor;
            PrintColorMsg(ConsoleColor.Yellow, infoString);
        }

        static void WelcomeUser(){
            // Ask user name
            Console.Write("What is your name? ");

            // Get user input
            string inputName = Console.ReadLine();

            // Welcome msg
            Console.WriteLine("Hello {0}, let's play a game...", inputName);
        }

        static void PrintColorMsg(ConsoleColor color, string msg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static bool ValidateGuess(string guessInput){
            int guessNumber;
            bool validGuess = int.TryParse(guessInput, out guessNumber);
            Console.WriteLine("{0} {1} {2}", guessNumber, guessNumber.GetType().Name, validGuess);
            return validGuess;
        }
    }
}
