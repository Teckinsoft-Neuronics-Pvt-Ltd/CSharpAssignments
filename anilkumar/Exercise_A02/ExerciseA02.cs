using System;

namespace ExerciseA02
{
    class GuessingGame{
        static void Main(string[] args){
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            int noOfTries = 1;
            while (noOfTries <= 7) // Max No of Tries = 7
            {
                Console.WriteLine("Enter your Guess:");
                if (!int.TryParse(Console.ReadLine(), out int inputNumber) || (inputNumber > 100)){
                    Console.WriteLine("Please enter a valid Number between 1 to 100");
                    continue;
                }
                if (inputNumber > randomNumber){
                    Console.WriteLine("Your guess is too high");
                    noOfTries++;
                }
                else if (inputNumber < randomNumber){
                    Console.WriteLine("Your guess is too low");
                    noOfTries++;
                }
                else{
                    Console.WriteLine($"Yayyy...You guessed it correctly in {noOfTries} tries");
                    break;
                }
            }
        }
    }
}
