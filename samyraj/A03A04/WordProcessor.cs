
namespace A03A04
{
    internal class WordProcessor
    {
        internal char[] seeds = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
        internal List<string>? words { get => this.GetWords();}
        internal string? text { get => this.ReadAllTextFrmFile(); } 
        internal string file { get =>  this.GetFile(); }
        internal WordProcessor() { this.GetWords(); }
        internal List<string> GetWords()
        {
            if(!File.Exists(file)) return null!;
            return this.ReadLinesFromTxtFlie();
        }
        string GetFile() => @"D:\words.txt";
        List<string> ReadLinesFromTxtFlie() =>  File.ReadAllLines(GetFile()).ToList();
        string ReadAllTextFrmFile () => File.ReadAllText(GetFile());
        internal List<string> GetWordWithMinimumLength(List<string> words) => this.words!.ToList().Where(s => s.Length >= 4).ToList();
        internal int Point(string word) => word.Length == 4 ? 1 : IsPangram(word) ? word.Length + 7 : word.Length;
        internal bool IsValidFirstSeed(string word)
        {
            if (word.IndexOf(seeds[0], StringComparison.OrdinalIgnoreCase) == -1) return false;
            return word.All(c => this.seeds.Any(x => string.Equals(x.ToString(), c.ToString(), StringComparison.OrdinalIgnoreCase))); 
        }
        internal bool IsPangram(string word)
        {
            int i = 0;
            bool sucess = true;
            while (i < this.seeds.Length - 1 && sucess)
            {
                var letter = this.seeds[i];
                sucess = word.Any(w => string.Equals(w.ToString(), letter.ToString(), StringComparison.OrdinalIgnoreCase));
                i++;
            }
            return sucess;
        }
    }
}

