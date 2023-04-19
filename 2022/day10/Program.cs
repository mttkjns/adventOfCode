// See https://aka.ms/new-console-template for more information
var input = File.ReadAllLines("input.txt").Select(x => x.Split(' '));

int x = 1;
int cycle = 1;

var checkCycles = new List<int> { 20, 60, 100, 140, 180, 220 };

var cycleStrength = 0;

foreach (var opp in input)
{
    cycle++;
    
    if (checkCycles.Contains(cycle))
        cycleStrength += cycle * x;

    if (opp.Length > 1)
    {
        cycle++;
        x += int.Parse(opp[1]);
        if (checkCycles.Contains(cycle))
            cycleStrength += cycle * x;
    }
}

Console.WriteLine(cycleStrength);
Console.WriteLine(39 / 40);