var stream = File.OpenText("input.txt");

int startOfPacketWindow = 4;
int startOfMessageWindow = 14;

var packetStartPos = GetStartMarker(0, startOfPacketWindow);
System.Console.WriteLine(packetStartPos);

var messageStartPos = GetStartMarker(packetStartPos, startOfMessageWindow);
System.Console.WriteLine(messageStartPos);

int GetStartMarker(int streamPosition, int windowSize)
{
    var buffer = new Queue<int>();

    while (buffer.Distinct().Count() != windowSize) 
    {
        buffer.Enqueue(stream.Read());
        streamPosition++;;

        if (buffer.Count > windowSize)
            _ = buffer.Dequeue();
    }

    return streamPosition;
}