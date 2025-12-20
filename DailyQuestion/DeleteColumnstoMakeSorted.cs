namespace DailyQuestion
{
    public class DeleteColumnstoMakeSorted
    {
        public int MinDeletionSize(string[] stringArray)
        {
            int totalRows = stringArray.Length;
            int totalColumns = stringArray[0].Length;
            int columnsToDelete = 0;

            for(int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                for(int rowIndex = 1; rowIndex < totalRows; rowIndex++)
                {
                    if(stringArray[rowIndex][columnIndex] < stringArray[rowIndex - 1][columnIndex])
                    {
                        columnsToDelete++;
                        break;
                    }
                }
            }

            return columnsToDelete;
        }
    }
}