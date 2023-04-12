var input = File.ReadAllLines("input.txt");
int visible = 0;
int maxScenicScore = 0;

//nested for loops, traverse 2D array
for (int row = 0; row < input.Length; row++)
{
    for (int col = 0; col < input.Length; col++)
    {
        int pos = input[row][col] - '0';

        bool vVisUp = input.Take(row).All(v => pos > v[col] - '0');
        bool vVisDown = input.Skip(row + 1).All(v => pos > v[col] - '0');
        bool hVisLeft = input[row].Take(col).All(h => pos > h - '0');
        bool hVisRight = input[row].Skip(col + 1).All(h => pos > h - '0');

        if (vVisUp || vVisDown || hVisLeft || hVisRight)
            visible++;

        //skip edges, don't need this
        if (row == 0 || col == 0)
            continue;
        if (row == (input.Length - 1) || col == (input.Length - 1))
            continue;

        //4/11
        //you're having issues when you hit the edge. No need for the "+ 1" if we've searched all the available trees.
        
        int scenicScoreUp = input.Take(row).Select(x => x[col]).Reverse().TakeWhile(x => (x - '0') < pos).Count() + 1;
        int scenicScoreDown = input.Skip(row + 1).Select(x => x[col]).TakeWhile(x => (x - '0') < pos ).Count() + 1;
        int scenicScoreLeft = input[row].Take(col).Reverse().TakeWhile(x => (x - '0') < pos ).Count() + 1;
        int scenicScoreRight = input[row].Skip(col + 1).TakeWhile(x => (x - '0') < pos ).Count() + 1;

        int scenicScore = scenicScoreUp * scenicScoreDown * scenicScoreLeft * scenicScoreRight;

        if (scenicScore > maxScenicScore)
            maxScenicScore = scenicScore;
    }
}

Console.WriteLine(visible);
System.Console.WriteLine(maxScenicScore);

