
namespace A02
{
    static internal class GuessingGame
    {
        static int noofTry = 1;
        static bool isSuccess = default(bool);
        static internal void GuessNumber(int secretnumber)
        {
            while (!isSuccess)
            {
                Console.WriteLine($"\nNo. {noofTry}");
                Console.Write("Please guess the number 1-100 : ");
            
                if (int.TryParse(Console.ReadLine(),out int num))
                {
                    if (num > 0 && num <= 100)
                    {
                        switch (num)
                        {
                            case var n when num == secretnumber:
                                isSuccess = true;
                                Console.WriteLine($"\ncongratulations!.You guessed correctly. No of tries: {noofTry} ");
                                break;

                            case var n when num < secretnumber:
                                Console.WriteLine("Your guess is too low.");
                                break;

                            case var n when num > secretnumber:
                                Console.WriteLine("Your guess is too high.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter the number between 1-100. Try again.. ");
                        noofTry -= 1;
                    }
                } 
                else
                {
                    Console.WriteLine("\nInvalid input");
                    noofTry -= 1;
                }
                noofTry++;
            }
        }

    }
}

