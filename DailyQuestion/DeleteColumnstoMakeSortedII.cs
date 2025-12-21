namespace DailyQuestion
{
    public class DeleteColumnstoMakeSortedII
    {
        public int MinDeletionSize(string[] stringArray)
        {
            int totalRows = stringArray.Length;
            int totalColumns = stringArray[0].Length;

            bool[] isSorted = new bool[totalRows - 1];
            int columnsToDelete = 0;

            for(int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                bool columnShouldBeDeleted = false;

                for(int rowIndex = 0; rowIndex < totalRows - 1; rowIndex++)
                {
                    if(!isSorted[rowIndex] && stringArray[rowIndex][columnIndex] > stringArray[rowIndex + 1][columnIndex])
                    {
                        columnShouldBeDeleted = true;
                        break;
                    }
                }

                if(columnShouldBeDeleted)
                {
                    columnsToDelete++;
                    continue;
                }

                for(int rowIndex = 0; rowIndex < totalRows - 1; rowIndex++)
                {
                    if(!isSorted[rowIndex] && stringArray[rowIndex][columnIndex] < stringArray[rowIndex + 1][columnIndex])
                    {
                        isSorted[rowIndex] = true;
                    }
                }
            }

            return columnsToDelete;
        }
    }
}