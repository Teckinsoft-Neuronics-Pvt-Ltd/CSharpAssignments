using A02;
internal class Program
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 100);

        Console.WriteLine("-----Guessing Game-----");
        ReverseGuessing.Search();
        Console.WriteLine("-----Reverse Guessing Game-----");
        GuessingGame.GuessNumber(secretNumber);
        Console.ReadLine();
    }
}
