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


//part II
x = 1;
cycle = 0;
var screen = new char[6,40];

foreach (var opp in input)
{
    Tick();
    if (opp.Length > 1)
    {
        Tick();
        x += int.Parse(opp[1]);
    }
}

for (int row = 0; row < screen.GetLength(0); row++)
{
    for (int col = 0; col < screen.GetLength(1); col++)
    {
        Console.Write(screen[row, col]);
    }
    Console.WriteLine();
}

void Tick()
{
    var sprite = Enumerable.Range(x - 1, 3);

    int drawing = cycle % 40;
    int onRow = cycle / 40;

    screen[onRow, drawing] = sprite.Contains(drawing) ? '#' : '.';
   
    cycle++;
}

