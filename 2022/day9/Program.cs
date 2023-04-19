// See https://aka.ms/new-console-template for more information
var input = File.OpenText("input.txt");

var hPos = new List<string>();
var tPos = new List<string>();
string line;
//x,y signed int
int hX = 0, hY = 0, tX= 0, tY = 0;

while ((line = input.ReadLine()) is not null)
{
    var inst = Parse(line);

    for (int i = 0; i < int.Parse(inst[1]); i++)
    {
        switch (inst[0])
        {
            case "U" : 
                hY++;
                if ((hY - tY) > 1)
                {
                    tX = hX;
                    tY = hY - 1;
                }
                break;
            case "D" : 
                hY--;
                if ((tY - hY) > 1)
                {
                    tX = hX;
                    tY = hY + 1;
                }
                break;
            case "L" : 
                hX--;
                if ((tX - hX) > 1)
                {
                    tY = hY;
                    tX = hX + 1;
                }
                break;
            case "R" : 
                hX++;
                if ((hX - tX) > 1)
                {
                    tY = hY;
                    tX = hX - 1;
                }
                break;
            default : break;
        }
        tPos.Add($"{tX},{tY}");
    }
}

Console.WriteLine(tPos.Distinct().Count());

input.Dispose();

static string[] Parse(string move) => move.Split(' ');

//part II - stoled from nawill81 https://github.com/nawill81/AdventOfCode/blob/master/2022/Day9.linq

var part2 = File.ReadLines("input.txt").Select(x => 
    new { Direction = x.First(), Distance = int.Parse(x.Substring(x.IndexOf(' '))) });

HashSet<(int, int)> visited = new();
var knots = new (int X, int Y)[10];

foreach (var move in part2)
{
    for (int i = 0; i < move.Distance; i++)
    {
        knots[0] = move.Direction switch
        {
            'L' => (--knots[0].X, knots[0].Y),
            'R' => (++knots[0].X, knots[0].Y),
            'U' => (knots[0].X, ++knots[0].Y),
            'D' => (knots[0].X, --knots[0].Y),
            _ => throw new InvalidOperationException("we broke"),
        };

        for (int j = 1; j < 10; j++)
        {
            var xDist = knots[j - 1].X - knots[j].X;
            var yDist = knots[j - 1].Y - knots[j].Y;

            if (Math.Abs(xDist) > 1 || Math.Abs(yDist) > 1)
            {
                knots[j].X += Math.Sign(xDist);
                knots[j].Y += Math.Sign(yDist);
            }
        }

        visited.Add(knots.Last());
    }
}

Console.WriteLine(visited.Count);