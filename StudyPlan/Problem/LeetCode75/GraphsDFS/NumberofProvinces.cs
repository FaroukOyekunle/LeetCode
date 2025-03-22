using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyPlan.Problem.LeetCode75.GraphsDFS
{
    public class NumberofProvinces
    {
        public int FindCircleNum(int[][] isConnected) 
        {
            int n = isConnected.Length;
            bool[] visited = new bool[n];
            int provinces = 0;
            
            for(int i = 0; i < n; i++) 
            {
                if(!visited[i]) 
                {
                    provinces++;
                    DFS(isConnected, visited, i);
                }
            }
            
            return provinces;
        }

        private void DFS(int[][] isConnected, bool[] visited, int city) 
        {
            visited[city] = true;
            for(int j = 0; j < isConnected.Length; j++) 
            {
                if(isConnected[city][j] == 1 && !visited[j]) 
                {
                    DFS(isConnected, visited, j);
                }
            }
        }
    }
}