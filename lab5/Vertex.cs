namespace GraphsConsole;

public class Vertex
{
    public int Number { get; set; }
    public bool Oriented { get; set; }
    public bool Visited { get; set; }

    public double X { get; set; }
    public double Y { get; set; }

    public Vertex(int number)
    {
        Number = number;
    }

    public override string ToString()
    {
        return $"{Number}, {Visited}";
    }
}