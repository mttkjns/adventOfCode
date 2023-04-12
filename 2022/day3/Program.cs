var input = File.ReadLines("input.txt");

var pairs = input.Select(x => 
    Tuple.Create<string, string>(x.Substring(0, x.Length / 2), x.Substring(x.Length / 2)));

int prioritySum = 0;
int lowerStart = 'a' - 1;
int upperStart = 'A' - 1;

var lowerDict = Enumerable.Range(1, 26)
    .ToList()
    .ToDictionary(k => (char)(lowerStart + k), v => v);

var upperDict = Enumerable.Range(1, 26)
    .ToList()
    .ToDictionary(k => (char)(upperStart + k), v => v + 26);

var dict = lowerDict.Concat(upperDict).ToDictionary(k => k.Key, v => v.Value);

foreach (var pair in pairs)
{
    char letter = pair.Item1.Where(x => pair.Item2.Contains(x)).Distinct().Single();
    System.Console.WriteLine($"value: {letter} int: {dict[letter]}");
    prioritySum += dict[letter];
}

System.Console.WriteLine(prioritySum);

int badgePrioritySum = 0;

foreach (var grp in input.Chunk(3))
{
    var letters = grp.First().Distinct();

    var matches = grp.Skip(1).First().Distinct().Where(x => letters.Contains(x)).Distinct();
    var allMatches = grp.Skip(2).First().Distinct().Where(x => letters.Contains(x) && matches.Contains(x)).Distinct();
    badgePrioritySum += allMatches.Select(x => dict[x]).Sum();
}

System.Console.WriteLine(badgePrioritySum);
