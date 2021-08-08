using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsMerge
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<IList<string>>()
            {
                new List<string>() { "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                new List<string>() { "John", "johnsmith@mail.com", "john00@mail.com" },
                new List<string>() { "Mary", "mary@mail.com" },
                new List<string>() { "John", "johnnybravo@mail.com" }
            };

            var result = new Solution().AccountsMerge(list);

            foreach (var r in result)
            {
                Console.WriteLine(string.Join(",", r));
            }
        }
    }
}

public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        var unionSet = new DisjointUnionSets(10001);

        var emailToName = new Dictionary<string, string>();
        var emailToId = new Dictionary<string, int>();

        var id = 0;

        foreach (var account in accounts)
        {
            var name = account[0];

            for (var i = 1; i < account.Count; i++)
            {
                var email = account[i];

                emailToName[email] = name;

                if (!emailToId.ContainsKey(email))
                {
                    emailToId[email] = id++;
                }
                
                unionSet.Union(emailToId[account[1]], emailToId[email]);
            }
        }

        var result = new Dictionary<int, List<string>>();

        foreach (var email in emailToName.Keys)
        {
            var index = unionSet.Find(emailToId[email]);
            if (!result.ContainsKey(index))
            {
                result[index] = new List<string>();
            }
            
            result[index].Add(email);
        }

        foreach (var emails in result.Values)
        {
            emails.Sort(string.CompareOrdinal);
            emails.Insert(0, emailToName[emails[0]]);
        }

        return new List<IList<string>>(result.Values);
    }
    
    public class DisjointUnionSets
    {
        private int _size;

        private int[] _rank;
        private int[] _parent;
        
        public DisjointUnionSets(int size)
        {
            _size = size;
            
            _rank = new int[size];
            _parent = new int[size];
            
            MakeSet();
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int x)
        {
            if (_parent[x] != x)
            {
                _parent[x] = Find(_parent[x]);
            }

            return _parent[x];
        }

        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[rootX] < _rank[rootY])
            {
                _parent[rootX] = rootY;
            } 
            else if (_rank[rootY] < _rank[rootX])
            {
                _parent[rootY] = rootX;
            }
            else
            {
                _parent[rootY] = rootX;
                _rank[rootX] = _rank[rootX] + 1;
            }
        }

        private void MakeSet()
        {
            for (var i = 0; i < _size; i++)
            {
                _parent[i] = i;
            }
        }
    }
}