var input = File.ReadAllLines("input.txt");

//get arrangement
var arrangement = input.TakeWhile(x => !String.IsNullOrWhiteSpace(x)).ToArray();
var height = arrangement.Count();
var width = arrangement.Last()
    .Split(' ')
    .Where(y => !String.IsNullOrWhiteSpace(y))
    .Select(z => int.Parse(z))
    .Max();

Stack<char>[] test = new Stack<char>[width];

for (int i = 0; i < width; i++)
    test[i] = new Stack<char>();

for (int i = height - 2; i >= 0; i--)
{
    for (int j = 1; j <= width; j++)
    {
        var col = arrangement.Last().IndexOf(j.ToString());
        if (arrangement[i][col] != ' ')
            test[j - 1].Push(arrangement[i][col]);
    }
}

//get moves
var moves = input.SkipWhile(x => !String.IsNullOrWhiteSpace(x)).Where(x => !String.IsNullOrEmpty(x));

//remove move, from, to. Split on ' '. Where not empty.
moves = moves.Select(x => 
    x.Replace("move", String.Empty).Replace("from", String.Empty).Replace("to", String.Empty).Trim());

var movesParsed = moves.Select(x => 
    (x.Split(' ').Where(y => !String.IsNullOrEmpty(y)).Select(z => int.Parse(z)).ToArray()));

//make moves
//[0] how many
//[1] from index
//[2] to index

foreach (var move in movesParsed)
{
    var nineThousandOne = new Stack<char>();
    for (int i = 0; i < move[0]; i++)
    {
        var crate = test[move[1] - 1].Pop();
        nineThousandOne.Push(crate);
        //test[move[2] - 1].Push(crate);        
    }

    while (nineThousandOne.Any())
        test[move[2] - 1].Push(nineThousandOne.Pop());
}

//report top row
System.Console.WriteLine(test.Select(x => x.Peek()).ToArray());