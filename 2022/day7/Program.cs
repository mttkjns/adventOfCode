var input = File.OpenText("input.txt");

int maxDirectorySize = 100000;

var filePath = new Stack<string>();
var directorySizes = new Dictionary<string, int>();

string? line;

while((line = input.ReadLine()) is not null)
{
    if (line.StartsWith("$ cd"))
    {
        var commandLine = line.Split(' ');
        var directory = commandLine[2];

        if (directory == "..")
            filePath.Pop();
        else 
            filePath.Push(directory);
    }
    else if (line.StartsWith("$ ls"))
        continue;
    else
    {
        int size;
        if (!int.TryParse(line.Split(' ')[0], out size))
            continue;
        foreach (int i in Enumerable.Range(1, filePath.Count))
        {
            var key = String.Join('/', filePath.Skip(filePath.Count - i).Reverse());
            if (directorySizes.ContainsKey(key))
                directorySizes[key] += size;
            else
                directorySizes[key] = size;
        }            
    }
}

var total = directorySizes.Where(x => x.Value <= maxDirectorySize).Sum(x => x.Value);

System.Console.WriteLine(total);

int diskSize = 70000000;
int updateSize = 30000000;

int inUse = diskSize - directorySizes["/"];

int needToClear = updateSize - inUse;

System.Console.WriteLine(needToClear);

var dirToDelete = directorySizes.Where(x => x.Value >= needToClear).Min(x => x.Value);

System.Console.WriteLine(dirToDelete);