namespace DailyQuestion
{
    public class PowerGridMaintenance
    {
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            var parent = new int[c + 1];
            var rank = new int[c + 1];
            for (int i = 1; i <= c; i++)
            {
                parent[i] = i;
            }

            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }

                return parent[x];
            }

            void Union(int a, int b)
            {
                int pa = Find(a), pb = Find(b);
                if (pa == pb)
                {
                    return;
                }

                if (rank[pa] < rank[pb])
                {
                    parent[pa] = pb;
                }

                else if (rank[pb] < rank[pa])
                {
                    parent[pb] = pa;
                }

                else
                {
                    parent[pb] = pa;
                    rank[pa]++;
                }
            }

            foreach (var con in connections)
            {
                Union(con[0], con[1]);
            }

            var heaps = new Dictionary<int, PriorityQueue<int, int>>();
            for (int i = 1; i <= c; i++)
            {
                int root = Find(i);
                if (!heaps.ContainsKey(root))
                {
                    heaps[root] = new PriorityQueue<int, int>();
                }

                heaps[root].Enqueue(i, i);
            }

            var isOnline = new bool[c + 1];

            for(int i = 1; i <= c; i++)
            {
                isOnline[i] = true;
            }

            var results = new List<int>();

            foreach (var q in queries)
            {
                int type = q[0];
                int x = q[1];

                if (type == 2)
                {
                    isOnline[x] = false;
                }

                else
                {
                    if (isOnline[x])
                    {
                        results.Add(x);
                        continue;
                    }

                    int root = Find(x);
                    var heap = heaps[root];

                    while (heap.Count > 0 && !isOnline[heap.Peek()])
                    {
                        heap.Dequeue();
                    }

                    if (heap.Count == 0)
                    {
                        results.Add(-1);
                    }
                    else
                    {
                        results.Add(heap.Peek());
                    }
                }
            }

            return results.ToArray();

        }
    }
}