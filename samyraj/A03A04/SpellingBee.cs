
namespace A03A04
{
    internal class SpellingBee : WordProcessor
    {
        internal SpellingBee() : base() { }
        internal void DisplayScores()
        {
            var _points = this.CalculateSpllingBeeScores();
            var orderByPoints = _points.OrderByDescending(k => k.Item2);
            foreach (var data in orderByPoints)
            {
                if(data.isPangram) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {data.point}. {data.word}");
                Console.ResetColor();
            }
            Console.WriteLine("----------");
            Console.WriteLine($"Total: {_points.Sum(k=>k.point) } ");
        }
        internal List<(string word, int point, bool isPangram)> CalculateSpllingBeeScores()
        {
            List<(string word,int point,bool isPangram)> _points = new();
            var wordsLists = this.GetWordWithMinimumLength(this.words!);
            if (wordsLists is not null)
            {
                foreach (var word in wordsLists)
                {
                    if (IsValidFirstSeed(word))
                    {
                        _points.Add((word, this.Point(word), IsPangram(word)));
                    }
                }
            }
            return _points;
        }
    }
}
