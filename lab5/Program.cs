namespace GraphsConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph("table.csv");
            //g.DepthSearch();
            Graph gr = new Graph();
            for (int i = 0; i < 5; i++)
            {
                gr.CreateVertex();
            }
            gr.CreateEdge(gr.Vertexes[0], gr.Vertexes[1]);
            gr.CreateEdge(gr.Vertexes[0], gr.Vertexes[2]);
            gr.CreateEdge(gr.Vertexes[0], gr.Vertexes[3]);
            gr.CreateEdge(gr.Vertexes[2], gr.Vertexes[1]);
            gr.CreateEdge(gr.Vertexes[2], gr.Vertexes[4]);

            gr.DepthSearch();
        }
    }
}