namespace GraphsConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph("table.csv");
            g.DepthSearch();
        }
    }
}