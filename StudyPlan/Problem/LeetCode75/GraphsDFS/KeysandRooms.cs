namespace StudyPlan.Problem.LeetCode75.GraphsDFS
{
    public class KeysandRooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms) 
        {
    
            int n = rooms.Count;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();

            visited[0] = true;
            queue.Enqueue(0);
            
            while(queue.Count > 0) 
            {
                int room = queue.Dequeue();
                foreach(int key in rooms[room]) 
                {
                    if(!visited[key]) 
                    {
                        visited[key] = true;
                        queue.Enqueue(key);
                    }
                }
            }

            foreach(bool v in visited) 
            {
                if(!v)
                {
                    return false;
                } 
            }
            return true;
        }
    }
}