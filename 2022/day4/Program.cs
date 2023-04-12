var input = File.ReadAllLines("input.txt");

int overlapAllCount = 0;
int overlapAnyCount = 0;

foreach (var line in input)
{
    var pair = line.Split(',');

    var one = pair[0].Split('-').Select(x => int.Parse(x)).ToArray();
    var two = pair[1].Split('-').Select(x => int.Parse(x)).ToArray();
    
    //var oneRange = Enumerable.Range(int.Parse(one[0]), int.Parse(one[1]) - int.Parse(one[0]) + 1);
    //var twoRange = Enumerable.Range(int.Parse(two[0]), int.Parse(two[1]) - int.Parse(two[0]) + 1);

    //this isn't good, what if the ranges are HUGE?? you should just check comparisons on each int
    // if (oneRange.Any(x => twoRange.Contains(x)))
    //     overlapAnyCount++;

    if ((two[0] <= one[1] && two[0] >= one[0]) || (one[0] <= two[1] && one[0] >= two[0]))
        overlapAnyCount++;

    // if (oneRange.All(x => twoRange.Contains(x)) || twoRange.All(x => oneRange.Contains(x)))
    //     overlapAllCount++;

    if ((one[0] <= two[0] && one[1] >= two[1]) || (two[0] <= one[0] && two[1] >= one[1]))
        overlapAllCount++;
}

System.Console.WriteLine($"Overlap All: {overlapAllCount}");
System.Console.WriteLine($"Overlap Any: {overlapAnyCount}");