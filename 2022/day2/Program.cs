
var strat = File.ReadAllLines("day2_input.txt");

var rps = new Dictionary<char, string>
{
    {'X', "rock"},
    {'Y', "paper"},
    {'Z', "scissor"},
    {'A', "rock"},
    {'B', "paper"},
    {'C', "scissor"}
};

var whatDoYouBeat = new Dictionary<string, string>
{
    {"rock", "scissor"},
    {"paper", "rock"},
    {"scissor", "paper"}
};

var whatDoYouScore = new Dictionary<string, int>
{
    {"rock", 1},
    {"paper", 2},
    {"scissor", 3}
};

int myScore = 0;
int wins = 0;
int draws = 0;
int loss = 0;
int r = 0;

foreach (var round in strat)
{
    r++;
    var input = round.Split(' ').Select(x => x.Single()).ToArray();

    myScore += whatDoYouScore[rps[input[1]]];

    //draw +3
    if (rps[input[0]] == rps[input[1]]){
        myScore += 3;
        draws++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Draw: {myScore}");
    }
    //winner +6
    else if (Winner(input[1], input[0])) {
        myScore += 6;
        wins++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Winner: {myScore}");
    }
    else {
        loss++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Loser: {myScore}");
    }
}

System.Console.WriteLine($"wins: {wins}, Draws: {draws}, Losses: {loss}, total: {wins + draws + loss}");

r = 0;
myScore = 0;
wins = 0;
draws = 0;
loss = 0;

foreach (var round in strat)
{
    r++;
    var input = round.Split(' ').Select(x => x.Single()).ToArray();

    var stratInput = Strategy(input[1], input[0]);

    myScore += whatDoYouScore[stratInput];

    //draw +3
    if (rps[input[0]] == stratInput){
        myScore += 3;
        draws++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Draw: {myScore}");
    }
    //winner +6
    else if (whatDoYouBeat[stratInput] == rps[input[0]]) {
        myScore += 6;
        wins++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Winner: {myScore}");
    }
    else {
        loss++;
        Console.WriteLine($"Round {r}: {input[0]}/{rps[input[0]]} {input[1]}/{rps[input[1]]} Loser: {myScore}");
    }
}

System.Console.WriteLine($"wins: {wins}, Draws: {draws}, Losses: {loss}, total: {wins + draws + loss}");

//function for winner
bool Winner(char player1, char player2)
{
    if (whatDoYouBeat[rps[player1]] == rps[player2])
        return true;
    else
        return false;
}

string Strategy(char me, char opp) => 
    me switch
    {
        'X' => whatDoYouBeat[rps[opp]],
        'Y' => rps[opp],
        'Z' => whatDoYouBeat.Values.First(x => (x != rps[opp]) && x != whatDoYouBeat[rps[opp]]),
        _ => throw new ArgumentOutOfRangeException("X Y OR Z")
    };