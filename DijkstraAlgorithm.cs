namespace DijkstrasAlgorithm;

public class DijkstraAlgorithm
{
    public static int[] CalculateShortestPath(int[,] graph, int source)
    {
        int n = graph.GetLength(0);
        int[] distance = new int[n];
        bool[] visited = new bool[n];

        //initialized each distance to infinite and visited to not visited
        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }

        //distance of source node from itself is zero
        distance[source] = 0;

        for (int i = 0; i < n; i++)
        {
            int minDistance = int.MaxValue;
            int index = 0;

            //check for node are visited or not
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && distance[j] <= minDistance)
                {
                    minDistance = distance[j];
                    index = j;
                }

            }
            // return new int[] { index };
            visited[index] = true;

            //update the distance of node
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && graph[index, j] != 0 && distance[index] != int.MaxValue && distance[index] + graph[index, j] < distance[j])
                {
                    distance[j] = distance[index] + graph[index, j];
                }
            }
        }

        return distance;
    }
}