namespace DailyQuestion
{
    public class MaximalRectangle
    {
        public int MaximalRectangle(char[][] binaryMatrix)
        {
            if(binaryMatrix == null || binaryMatrix.Length == 0)
            {
                return 0;
            }

            int totalRows = binaryMatrix.Length;
            int totalColumns = binaryMatrix[0].Length;

            int[] columnHeights = new int[totalColumns];
            int maximumRectangleArea = 0;

            for(int rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    columnHeights[columnIndex] = binaryMatrix[rowIndex][columnIndex] == '1' ? columnHeights[columnIndex] + 1 : 0;
                }

                maximumRectangleArea = Math.Max(maximumRectangleArea, CalculateLargestRectangleArea(columnHeights));
            }

            return maximumRectangleArea;
        }

        private int CalculateLargestRectangleArea(int[] columnHeights)
        {
            Stack<int> indexStack = new Stack<int>();
            int maximumArea = 0;
            int totalColumns = columnHeights.Length;

            for(int columnIndex = 0; columnIndex <= totalColumns; columnIndex++)
            {
                int currentHeight = (columnIndex == totalColumns) ? 0 : columnHeights[columnIndex];

                while(indexStack.Count > 0 && currentHeight < columnHeights[indexStack.Peek()])
                {
                    int height = columnHeights[indexStack.Pop()];
                    int width = indexStack.Count == 0 ? columnIndex : columnIndex - indexStack.Peek() - 1;
                    maximumArea = Math.Max(maximumArea, height * width);
                }

                indexStack.Push(columnIndex);
            }

            return maximumArea;
        }
    }
}