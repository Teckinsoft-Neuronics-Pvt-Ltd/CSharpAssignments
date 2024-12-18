string[] words = File.ReadAllLines("C:/Users/Anil kumar/Downloads/words.txt");
Dictionary<char,int> frequencyDict = new();
foreach (string word in words) {
    foreach (char c in word){
        if (!frequencyDict.ContainsKey(c)) frequencyDict[c] = 1;
        frequencyDict[c]++;
    }
}
frequencyDict = frequencyDict.OrderByDescending(dict => dict.Value).ToDictionary();
int count = 0;
foreach(var kv in frequencyDict)
    Console.WriteLine($"{++count,2}.character {kv.Key} , count : {kv.Value}");
Console.Write("\nThe Seed characters for Spelling Bee Program: ");
foreach(var key in frequencyDict.Keys.Take(7))
    Console.Write($"{key} ");
