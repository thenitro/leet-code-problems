using System.Collections.Generic;

public class Solution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var nodesFrom = new HashSet<int>();
        var nodesTo = new HashSet<int>();

        foreach (var edge in edges)
        {
            nodesFrom.Add(edge[0]);
            nodesTo.Add(edge[1]);
        }

        var result = new List<int>();

        foreach (var node in nodesFrom)
        {
            if (!nodesTo.Contains(node))
            {
                result.Add(node);
            }
        }

        return result;
    }
}