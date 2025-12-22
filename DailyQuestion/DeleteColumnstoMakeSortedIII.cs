namespace DailyQuestion
{
    public class DeleteColumnstoMakeSortedIII
    {
        public int MinDeletionSize(string[] stringArray)
        {
            int totalRows = stringArray.Length;
            int totalColumns = stringArray[0].Length;

            int[] longestIncreasingSubsequence = new int[totalColumns];
            Array.Fill(longestIncreasingSubsequence, 1);

            for(int currentColumn = 0; currentColumn < totalColumns; currentColumn++)
            {
                for(int previousColumn = 0; previousColumn < currentColumn; previousColumn++)
                {
                    bool isSortable = true;

                    for(int rowIndex = 0; rowIndex < totalRows; rowIndex++)
                    {
                        if(stringArray[rowIndex][previousColumn] > stringArray[rowIndex][currentColumn])
                        {
                            isSortable = false;
                            break;
                        }
                    }

                    if(isSortable)
                    {
                        longestIncreasingSubsequence[currentColumn] = Math.Max(longestIncreasingSubsequence[currentColumn], longestIncreasingSubsequence[previousColumn] + 1);
                    }
                }
            }

            int maximumKeptColumns = longestIncreasingSubsequence.Max();
            return totalColumns - maximumKeptColumns;
        }
    }
}