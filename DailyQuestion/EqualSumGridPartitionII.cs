namespace DailyQuestion
{
    public class EqualSumGridPartitionII
    {
        public bool CanPartitionGridWithOptionalCellAdjustment(int[][] inputGrid)
        {
            int totalRowCount = inputGrid.Length;
            int totalColumnCount = inputGrid[0].Length;

            long[] rowWiseSums = new long[totalRowCount];
            long[] columnWiseSums = new long[totalColumnCount];

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    rowWiseSums[rowIndex] += inputGrid[rowIndex][columnIndex];
                    columnWiseSums[columnIndex] += inputGrid[rowIndex][columnIndex];
                }
            }

            long totalGridSum = rowWiseSums.Sum();

            var valueToRowIndicesMap = new Dictionary<long, List<int>>();

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    long cellValue = inputGrid[rowIndex][columnIndex];

                    if (!valueToRowIndicesMap.ContainsKey(cellValue))
                    {
                        valueToRowIndicesMap[cellValue] = new List<int>();
                    }

                    if (valueToRowIndicesMap[cellValue].Count == 0 ||
                        valueToRowIndicesMap[cellValue][^1] != rowIndex)
                    {
                        valueToRowIndicesMap[cellValue].Add(rowIndex);
                    }
                }
            }

            var valueToColumnIndicesMap = new Dictionary<long, List<int>>();

            for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
                {
                    long cellValue = inputGrid[rowIndex][columnIndex];

                    if (!valueToColumnIndicesMap.ContainsKey(cellValue))
                    {
                        valueToColumnIndicesMap[cellValue] = new List<int>();
                    }

                    if (valueToColumnIndicesMap[cellValue].Count == 0 ||
                        valueToColumnIndicesMap[cellValue][^1] != columnIndex)
                    {
                        valueToColumnIndicesMap[cellValue].Add(columnIndex);
                    }
                }
            }

            bool DoesValueExistInRowRange(long targetValue, int startRow, int endRow)
            {
                if (!valueToRowIndicesMap.TryGetValue(targetValue, out var rowIndices))
                {
                    return false;
                }

                int firstValidIndex = FindFirstIndexGreaterOrEqual(rowIndices, startRow);

                return firstValidIndex < rowIndices.Count &&
                    rowIndices[firstValidIndex] <= endRow;
            }

            bool DoesValueExistInColumnRange(long targetValue, int startColumn, int endColumn)
            {
                if (!valueToColumnIndicesMap.TryGetValue(targetValue, out var columnIndices))
                {
                    return false;
                }

                int firstValidIndex = FindFirstIndexGreaterOrEqual(columnIndices, startColumn);

                return firstValidIndex < columnIndices.Count &&
                    columnIndices[firstValidIndex] <= endColumn;
            }

            bool IsValueAtRowEdges(long targetValue, int rowIndex)
            {
                return inputGrid[rowIndex][0] == targetValue ||
                    inputGrid[rowIndex][totalColumnCount - 1] == targetValue;
            }

            bool IsValueAtColumnEdges(long targetValue, int columnIndex)
            {
                return inputGrid[0][columnIndex] == targetValue ||
                    inputGrid[totalRowCount - 1][columnIndex] == targetValue;
            }

            long cumulativeTopPartitionSum = 0;

            for (int partitionRow = 0; partitionRow < totalRowCount - 1; partitionRow++)
            {
                cumulativeTopPartitionSum += rowWiseSums[partitionRow];

                long bottomPartitionSum = totalGridSum - cumulativeTopPartitionSum;
                long partitionDifference = cumulativeTopPartitionSum - bottomPartitionSum;

                if (partitionDifference == 0)
                {
                    return true;
                }

                int numberOfTopRows = partitionRow + 1;
                int numberOfBottomRows = totalRowCount - partitionRow - 1;

                if (partitionDifference > 0)
                {
                    if (numberOfTopRows == 1)
                    {
                        if (IsValueAtRowEdges(partitionDifference, 0))
                        {
                            return true;
                        }
                    }
                    else if (totalColumnCount == 1)
                    {
                        if (inputGrid[0][0] == partitionDifference ||
                            inputGrid[partitionRow][0] == partitionDifference)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (DoesValueExistInRowRange(partitionDifference, 0, partitionRow))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    long requiredValue = -partitionDifference;

                    if (numberOfBottomRows == 1)
                    {
                        if (IsValueAtRowEdges(requiredValue, totalRowCount - 1))
                        {
                            return true;
                        }
                    }
                    else if (totalColumnCount == 1)
                    {
                        if (inputGrid[partitionRow + 1][0] == requiredValue ||
                            inputGrid[totalRowCount - 1][0] == requiredValue)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (DoesValueExistInRowRange(requiredValue, partitionRow + 1, totalRowCount - 1))
                        {
                            return true;
                        }
                    }
                }
            }

            long cumulativeLeftPartitionSum = 0;

            for (int partitionColumn = 0; partitionColumn < totalColumnCount - 1; partitionColumn++)
            {
                cumulativeLeftPartitionSum += columnWiseSums[partitionColumn];

                long rightPartitionSum = totalGridSum - cumulativeLeftPartitionSum;
                long partitionDifference = cumulativeLeftPartitionSum - rightPartitionSum;

                if (partitionDifference == 0)
                {
                    return true;
                }

                int numberOfLeftColumns = partitionColumn + 1;
                int numberOfRightColumns = totalColumnCount - partitionColumn - 1;

                if (partitionDifference > 0)
                {
                    if (numberOfLeftColumns == 1)
                    {
                        if (IsValueAtColumnEdges(partitionDifference, 0))
                        {
                            return true;
                        }
                    }
                    else if (totalRowCount == 1)
                    {
                        if (inputGrid[0][0] == partitionDifference ||
                            inputGrid[0][partitionColumn] == partitionDifference)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (DoesValueExistInColumnRange(partitionDifference, 0, partitionColumn))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    long requiredValue = -partitionDifference;

                    if (numberOfRightColumns == 1)
                    {
                        if (IsValueAtColumnEdges(requiredValue, totalColumnCount - 1))
                        {
                            return true;
                        }
                    }
                    else if (totalRowCount == 1)
                    {
                        if (inputGrid[0][partitionColumn + 1] == requiredValue ||
                            inputGrid[0][totalColumnCount - 1] == requiredValue)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (DoesValueExistInColumnRange(requiredValue, partitionColumn + 1, totalColumnCount - 1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}