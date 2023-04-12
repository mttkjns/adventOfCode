var stream = File.OpenText("day1_input.txt");

var elves = new Dictionary<int, List<int>>();
int elfId = 0;

while (!stream.EndOfStream) 
{
    elves.Add(elfId, new List<int>());
    var line = stream.ReadLine(); 
    while(!String.IsNullOrEmpty(line)) 
    {
        elves[elfId].Add(int.Parse(line));
        line = stream.ReadLine();
    }
    elfId++;
}

Console.WriteLine(elves.Select(x => x.Value).Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum());






