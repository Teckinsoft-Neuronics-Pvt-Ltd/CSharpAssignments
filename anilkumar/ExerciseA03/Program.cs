using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

char[] chars = ['S', 'E', 'A', 'U', 'T', 'N', 'R'];
string[] words = File.ReadAllLines("C:/Users/Anil kumar/Downloads/words.txt");
List<(string word,int score,bool pangram)> validWords = new ();
foreach (var word in words){
    if (isValidWord(word)) {
        if (word.Length == 4) validWords.Add((word, 1, false));
        else if (isPangram(word)) validWords.Add((word, word.Length + 7, true)); //Pangram
        else validWords.Add((word, word.Length, false));
    }
}

validWords = validWords.OrderByDescending(e=>e.score).ThenBy(e=>e.word).ToList();

int Score =0;
foreach (var w in validWords) {
    if(w.pangram) Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{w.score,4}. {w.word}");
    Console.ResetColor();
    Score+=w.score;
}
Console.WriteLine("-----");
Console.WriteLine($"{Score,4} total");
bool isValidWord(string word) =>
       word.Length >= 4
            && word.Contains(chars[0])
            && word.All(chars.Contains);

bool isPangram(string word) {
    foreach (var c in chars) {
        if(!word.Contains(c)) return false;
    }
    return true;
}


