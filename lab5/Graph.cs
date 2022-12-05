using System.Runtime.ConstrainedExecution;

namespace GraphsConsole;

public class Graph
{
    public List<Vertex> Vertexes { get; private set; }
    public List<Edge> Edges { get; private set; }

    public Graph(string path)
    {
        Vertexes = GetVertexesFromTable(path);
        Edges = GetEdgesFromTable(path);
    }

    public void DepthSearch()
    {
        Stack<Vertex> stack = new Stack<Vertex>();
        Random rnd = new Random();
        int n = rnd.Next(1, Vertexes.Count);
        stack.Push(Vertexes[n]);

        recSearch(stack);
    }
    private void recSearch(Stack<Vertex> s)
    {
        if (s.Count == 0) return;
        Vertex ver = s.Pop();
        ver.Visited = true;
        Console.WriteLine(ver);

        for (int i = 0; i < Edges.Count; i++)
        {
            if (Edges[i].From != ver && Edges[i].To != ver) continue;

            if (Edges[i].From == ver && !Edges[i].To.Visited)//находим все смежные с опорной вершины
            {
                s.Push(Edges[i].To);
            }
            if (Edges[i].To == ver && !Edges[i].From.Visited)//находим все смежные с опорной вершины
            {
                s.Push(Edges[i].From);
            }
            recSearch(s);
        }
    }

    public void BreadthFirstSearch()
    {
        Queue<Vertex> queue = new Queue<Vertex>();
        Random rnd = new Random();
        int n = rnd.Next(1, Vertexes.Count);

        queue.Enqueue(Vertexes[n]);//step 1

        while (queue.Count > 0)//step 2
        {
            Vertex ver = queue.Dequeue();
            ver.Visited = true;//помечаем опорную вершину посещенной
            Console.WriteLine(ver);

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].From != ver && Edges[i].To != ver) continue;

                if (Edges[i].From == ver && !Edges[i].To.Visited && !queue.Contains(Edges[i].To))//находим все смежные с опорной вершины
                {
                    queue.Enqueue(Edges[i].To);//добавляем в очередь смежные вершины
                }
                if (Edges[i].To == ver && !Edges[i].From.Visited && !queue.Contains(Edges[i].From))//находим все смежные с опорной вершины
                {
                    queue.Enqueue(Edges[i].From);//добавляем в очередь смежные вершины
                }
            }
        }
    }

    private List<Vertex> GetVertexesFromTable(string path)
    {
        using (StreamReader sr = new StreamReader(path))
        {
            try
            {
                var line = sr.ReadLine();
                var columns = line.Trim().Split(';');
                List<Vertex> vertexes = CreateVertexes(columns.Length);

                return vertexes;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while reading table from file \n{e.Message}");
            }
        }

        return new List<Vertex>();
    }
    private List<Edge> GetEdgesFromTable(string path)
    {
        List<Edge> edges = new List<Edge>();

        using (StreamReader sr = new StreamReader(path))
        {
            try
            {
                var line = sr.ReadLine();
                int count = 0;
                while (line != null)
                {
                    Vertex currentVertex = GetVertex(count + 1);
                    var columns = line.Trim().Split(';');

                    for (int i = 0; i < columns.Length; i++)
                    {
                        if (columns[i] != "0")
                        {
                            int n = Int32.Parse(columns[i]);
                            edges.Add(new Edge(currentVertex, GetVertex(i + 1), n));
                        }
                    }

                    line = sr.ReadLine();
                    count++;
                }
                return edges;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while reading table from file \n{e.Message}");
            }
        }

        return new List<Edge>();
    }
    private List<Vertex> CreateVertexes(int count)
    {
        List<Vertex> v = new List<Vertex>();
        for (int i = 1; i <= count; i++)
        {
            v.Add(new Vertex(i));
        }

        return v;
    }
    private void CreateVertex()
    {
        int number = Vertexes.Count + 1;
        Vertexes.Add(new Vertex(number));
    }
    private void CreateEdge(Vertex v1, Vertex v2)
    {
        Edges.Add(new Edge(v1, v2));
    }
    private Vertex GetVertex(int number)
    {
        foreach (var vertex in Vertexes)
        {
            if (vertex.Number == number)
                return vertex;
        }
        throw new Exception("vertex wasn't found");
    }
}