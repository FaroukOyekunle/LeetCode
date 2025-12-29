namespace DailyQuestion
{
    public class PyramidTransitionMatrix
    {
        public bool PyramidTransition(string bottomRow, IList<string> allowedPatterns)
        {
            var patternToTopMap = new Dictionary<string, List<char>>();

            foreach(var pattern in allowedPatterns)
            {
                string basePattern = pattern.Substring(0, 2);
                char topBlock = pattern[2];

                if(!patternToTopMap.ContainsKey(basePattern))
                {
                    patternToTopMap[basePattern] = new List<char>();
                }

                patternToTopMap[basePattern].Add(topBlock);
            }

            var memoizedRows = new HashSet<string>();
            return CanBuildPyramid(bottomRow, patternToTopMap, memoizedRows);
        }

        private bool CanBuildPyramid(string currentRow, Dictionary<string, List<char>> patternToTopMap, HashSet<string> memoizedRows)
        {
            if(currentRow.Length == 1)
            {
                return true;
            }

            if(memoizedRows.Contains(currentRow))
            {
                return false;
            }

            var possibleNextRows = new List<string>();
            GenerateNextRows(currentRow, 0, "", patternToTopMap, possibleNextRows);

            foreach(var nextRow in possibleNextRows)
            {
                if(CanBuildPyramid(nextRow, patternToTopMap, memoizedRows))
                {
                    return true;
                }
            }

            memoizedRows.Add(currentRow);
            return false;
        }

        private void GenerateNextRows(string currentRow, int currentIndex, string currentPath, Dictionary<string, List<char>> patternToTopMap, List<string> possibleRows)
        {
            if(currentIndex == currentRow.Length - 1)
            {
                possibleRows.Add(currentPath);
                return;
            }

            string basePattern = currentRow.Substring(currentIndex, 2);

            if(!patternToTopMap.ContainsKey(basePattern))
            {
                return;
            }

            foreach(char topBlock in patternToTopMap[basePattern])
            {
                GenerateNextRows(currentRow, currentIndex + 1, currentPath + topBlock, patternToTopMap, possibleRows);
            }
        }
    }
}