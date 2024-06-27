// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for using Regex to find patterns
using System.Data;
using System.Text.RegularExpressions;

string teststr1 = "The quick brown Fox jumps over the lazy Dog";
string teststr2 = "the quick brown fox jumps over the lazy dog";

// TODO: The IsMatch function is used to determine if the content of a string
// results in a match with the given Regex
Regex CapWords = new Regex(@"[A-Z]\w+");
Console.WriteLine(CapWords.IsMatch(teststr1));
Console.WriteLine(CapWords.IsMatch(teststr2));

// TODO: The RegexOptions argument can be used to perform
// case-insensitive searches
Regex NoCase = new Regex(@"fox", RegexOptions.IgnoreCase);
Console.WriteLine(NoCase.IsMatch(teststr1));

// Use the Match and Matches methods to get information about
// specific Regex matches for a given pattern

// TODO: The Match method returns a single match at a time
Match m = CapWords.Match(teststr1);
while (m.Success){
    Console.WriteLine($"'{m.Value}' found at position {m.Index}");
    m = m.NextMatch();
}
//Regular expression can be used to replace content in string
//in addition to just searching for content
string result = CapWords.Replace(teststr1, "***");
Console.WriteLine(teststr1);
Console.WriteLine(result);

//Replacement text can be generated on the fly using MatchEvaluation
//This is a delegate that computes the new value of the replacement
string MakeUpper(Match m){
    string s = m.ToString();
    if(m.Index == 0){
        return s;
    }
    return s.ToUpper();
}
string upperstr = CapWords.Replace(teststr1,new MatchEvaluator(MakeUpper));
Console.WriteLine(teststr1);
Console.WriteLine(upperstr);

//The matches meathod returns a collection of Match objects
MatchCollection mc = CapWords.Matches(teststr1);
Console.WriteLine($"Found {mc.Count} matches:");
foreach (Match match in mc){
    Console.WriteLine($"'{match.Value}' found at position {match.Index}");
}

//Example file for Replacing content with REgexex
