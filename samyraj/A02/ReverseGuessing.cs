
namespace A02
{
    internal class ReverseGuessing
    {
        static int min = 1, max = 100, noofGuess = default(int);
        internal static int Search()
        {
            Console.WriteLine("\n Please guess number between 1-100. I am waiting...");
            Console.ReadLine();
            while (true)
            {
                int mid = MiddleNumber(min, max);

                Console.Write($"\nyour number is {mid} [Y/N]: ");

                var result = Console.ReadKey().Key;
                if (result == ConsoleKey.Y)
                {
                    Console.Write("\n Congratulations!.");
                    break;
                }
                Console.Write($"\n{mid} : is low or high [L/H]: ");
                if (Console.ReadKey().Key == ConsoleKey.L)
                {
                    min = mid;
                }
                else
                {
                    max = mid;
                }
                noofGuess++;
            }
            return noofGuess;
        }
        static int MiddleNumber(int num1, int num2) => (num1 + num2) / 2;
    }
}