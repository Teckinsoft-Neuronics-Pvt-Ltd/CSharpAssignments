
namespace A03A04
{
    internal class  ExtensionSpllingBee : SpellingBee
    {
        Dictionary<char, int> freq = new();
        internal  ExtensionSpllingBee() : base() { }  
        internal void ExtensionDisplayScores()
        {
            this.FrequencyWords();
            var orderTables = freq.OrderByDescending(o => o.Value).Take(7);
            foreach (var word in orderTables)
            {
               Console.WriteLine($"{word.Key} {word.Value}");
            }
        }
        private void FrequencyWords()
        {
           foreach (var ch in this.text!)
           {
                if (ch == '\r' || ch == '\n') continue;
                char upperChar = char.ToUpper(ch);
                if(freq.ContainsKey(upperChar))
                    freq[upperChar]++;
                else
                    freq[upperChar] = 1;
            }
        }
    }
}
