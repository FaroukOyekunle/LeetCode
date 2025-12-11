namespace DailyQuestion
{
    public class CounttheNumberofComputerUnlockingPermutations
    {
        const int MOD = 1_000_000_007;

        public int CountPermutations(int[] complexity)
        {
            int computerCount = complexity.Length;
            if(computerCount == 0) 
            {
                return 0;
            }

            int[] distinctComplexities = complexity.Distinct().ToArray();

            Array.Sort(distinctComplexities);
            var complexityToRank = new Dictionary<int, int>();

            for(int index = 0; index < distinctComplexities.Length; index++)
            {
                complexityToRank[distinctComplexities[index]] = index + 1;
            }

            int rankCount = distinctComplexities.Length;

            int[] complexityRank = new int[computerCount];
            for(int index = 0; index < computerCount; index++)
            {
                complexityRank[index] = complexityToRank[complexity[index]];
            }

            {
                int[] binaryIndexedTree = new int[rankCount + 2];
                Func<int, int> queryBinaryIndexedTree = (position) =>
                {
                    int sum = 0;
                    while (position > 0) { sum += binaryIndexedTree[position]; position -= position & -position; }
                    return sum;
                };

                Action<int, int> updateBinaryIndexedTree = (position, value) =>
                {
                    while (position < binaryIndexedTree.Length) { binaryIndexedTree[position] += value; position += position & -position; }
                };

                for(int index = 0; index < computerCount; index++)
                {
                    if(index > 0)
                    {
                        int unlockedCount = queryBinaryIndexedTree(complexityRank[index] - 1);
                        
                        if(unlockedCount == 0) 
                        {
                            return 0;
                        }
                    }

                    updateBinaryIndexedTree(complexityRank[index], 1);
                }
            }

            var indicesByRank = new List<int>[rankCount + 1];
            for(int rankIndex = 1; rankIndex <= rankCount; rankIndex++)
            {
                indicesByRank[rankIndex] = new List<int>();
            }

            for(int index = 1; index < computerCount; index++)
            {
                indicesByRank[complexityRank[index]].Add(index);
            }

            int[] listPointers = new int[rankCount + 1];

            int segmentSize = 1;
            while(segmentSize < rankCount)
            {
                segmentSize <<= 1;
            }

            int[] segmentTree = new int[2 * segmentSize];
            for(int index = 0; index < segmentTree.Length; index++)
            {
                segmentTree[index] = -1;
            }

            for(int rankIndex = 1; rankIndex <= rankCount; rankIndex++)
            {
                if(indicesByRank[rankIndex].Count > 0) 
                {
                    segmentTree[segmentSize + rankIndex - 1] = indicesByRank[rankIndex][indicesByRank[rankIndex].Count - 1];
                }

                else 
                {
                    segmentTree[segmentSize + rankIndex - 1] = -1;
                }
            }

            for(int index = segmentSize - 1; index >= 1; index--)
            {
                segmentTree[index] = Math.Max(segmentTree[2 * index], segmentTree[2 * index + 1]);

            }

            void UpdateSegRank(int rankIndex)
            {
                int segmentPosition = segmentSize + rankIndex - 1;
                segmentTree[segmentPosition] = (listPointers[rankIndex] < indicesByRank[rankIndex].Count) ? indicesByRank[rankIndex][indicesByRank[rankIndex].Count - 1] : -1;

                segmentPosition >>= 1;

                while(segmentPosition >= 1)
                {
                    segmentTree[segmentPosition] = Math.Max(segmentTree[2 * segmentPosition], segmentTree[2 * segmentPosition + 1]);
                    segmentPosition >>= 1;
                }
            }

            int FindRankWithMaxGreaterThan(int startRankIndex, int targetValue)
            {
                if (startRankIndex > rankCount) 
                {
                    return -1;
                }
                
                int segmentNode = 1, nodeRankLow = 1, nodeRankHigh = segmentSize;
                if(segmentTree[1] <= targetValue)
                {
                    return -1;
                }

                while(nodeRankLow != nodeRankHigh)
                {
                    int midRank = (nodeRankLow + nodeRankHigh) >> 1;
                    int leftChild = segmentNode * 2;
                    int rightChild = leftChild + 1;

                    if(startRankIndex <= midRank && segmentTree[leftChild] > targetValue)
                    {
                        segmentNode = leftChild;
                        nodeRankHigh = midRank;
                    }

                    else
                    {
                        segmentNode = rightChild;
                        nodeRankLow = midRank + 1;
                    }
                }

                if(nodeRankLow < startRankIndex || nodeRankLow > rankCount)
                {
                    return -1;
                }

                return nodeRankLow;
            }

            var availableQueue = new PriorityQueue<int, int>();

            bool[] isUnlocked = new bool[computerCount];
            isUnlocked[0] = true;

            for(int index = 1; index < computerCount; index++)
            {
                if(complexity[0] < complexity[index])
                {
                    availableQueue.Enqueue(index, index);
                }
            }

            var isRemovedFromList = new bool[computerCount];
            foreach(var rankIndex in Enumerable.Range(1, rankCount))
            {
                ;
            }

            foreach(var computerIndex in availableQueue.UnorderedItems.Select(t => t.Element))
            {
                isRemovedFromList[computerIndex] = true;
            }

            for(int rankIndex = 1; rankIndex <= rankCount; rankIndex++)
            {
                while(listPointers[rankIndex] < indicesByRank[rankIndex].Count && isRemovedFromList[indicesByRank[rankIndex][listPointers[rankIndex]]]) 
                {
                    listPointers[rankIndex]++;
                }

                segmentTree[segmentSize + rankIndex - 1] = (listPointers[rankIndex] < indicesByRank[rankIndex].Count) ? indicesByRank[rankIndex][indicesByRank[rankIndex].Count - 1] : -1;
            }

            for (int index = segmentSize - 1; index >= 1; index--)
            {
                segmentTree[index] = Math.Max(segmentTree[2 * index], segmentTree[2 * index + 1]);
            }

            long validPermutationCount = 1;
            int processedCount = 1;
            while(processedCount < computerCount)
            {
                if (availableQueue.Count == 0)
                {
                    return 0;
                }

                int availableChoices = availableQueue.Count;
                validPermutationCount = (validPermutationCount * availableChoices) % MOD;

                int selectedComputer = availableQueue.Dequeue();

                while(isUnlocked[selectedComputer])
                {
                    if(availableQueue.Count == 0) 
                    { 
                        availableChoices = 0; 
                        break; 
                    }

                    selectedComputer = availableQueue.Dequeue();
                }

                if(isUnlocked[selectedComputer]) 
                {
                    return 0;
                }

                isUnlocked[selectedComputer] = true;
                processedCount++;
                if(!isRemovedFromList[selectedComputer])
                {
                    isRemovedFromList[selectedComputer] = true;

                    int selectedRank = complexityRank[selectedComputer];
                    while(listPointers[selectedRank] < indicesByRank[selectedRank].Count && isRemovedFromList[indicesByRank[selectedRank][listPointers[selectedRank]]])
                    {
                        listPointers[selectedRank]++;
                    }

                    segmentTree[segmentSize + selectedRank - 1] = (listPointers[selectedRank] < indicesByRank[selectedRank].Count) ? indicesByRank[selectedRank][indicesByRank[selectedRank].Count - 1] : -1;
                    int segmentPosition = (segmentSize + selectedRank - 1) >> 1;
                    
                    while(segmentPosition >= 1) 
                    {
                        segmentTree[segmentPosition] = Math.Max(segmentTree[2 * segmentPosition], segmentTree[2 * segmentPosition + 1]); 
                        segmentPosition >>= 1; 
                    }
                }

                int nextRankBoundary = complexityRank[selectedComputer] + 1;

                while(true)
                {
                    int foundNextRank = FindRankWithMaxGreaterThan(nextRankBoundary, selectedComputer);
                    if (foundNextRank == -1)
                    {
                        break;
                    }

                    int listPtr = listPointers[foundNextRank];

                    while(listPtr < indicesByRank[foundNextRank].Count && isRemovedFromList[indicesByRank[foundNextRank][listPtr]]) 
                    {
                        listPtr++;
                    }

                    listPointers[foundNextRank] = listPtr;

                    int binarySearchLow = listPointers[foundNextRank], binarySearchHigh = indicesByRank[foundNextRank].Count;
                    while(binarySearchLow < binarySearchHigh)
                    {
                        int binarySearchMid = (binarySearchLow + binarySearchHigh) >> 1;
                        
                        if(indicesByRank[foundNextRank][binarySearchMid] <= selectedComputer) 
                        {
                            binarySearchLow = binarySearchMid + 1; 
                        }

                        else
                        {
                            binarySearchHigh = binarySearchMid;
                        }
                    }

                    int insertionStart = binarySearchLow;
                    if(insertionStart >= indicesByRank[foundNextRank].Count)
                    {
                        segmentTree[segmentSize + foundNextRank - 1] = (listPointers[foundNextRank] < indicesByRank[foundNextRank].Count) ? indicesByRank[foundNextRank][indicesByRank[foundNextRank].Count - 1] : -1;
                        int segmentPosition2 = (segmentSize + foundNextRank - 1) >> 1;
                        
                        while (segmentPosition2 >= 1) 
                        { 
                            segmentTree[segmentPosition2] = Math.Max(segmentTree[2 * segmentPosition2], segmentTree[2 * segmentPosition2 + 1]); 
                            segmentPosition2 >>= 1; 
                        }

                        continue;
                    }

                    for(int loopIndex = insertionStart; loopIndex < indicesByRank[foundNextRank].Count; loopIndex++)
                    {
                        int elementIndex = indicesByRank[foundNextRank][loopIndex];
                        if(!isRemovedFromList[elementIndex])
                        {
                            isRemovedFromList[elementIndex] = true;
                            availableQueue.Enqueue(elementIndex, elementIndex);
                        }
                    }

                    listPointers[foundNextRank] = indicesByRank[foundNextRank].Count;
                    segmentTree[segmentSize + foundNextRank - 1] = -1;
                    int segmentPosition3 = (segmentSize + foundNextRank - 1) >> 1;
                    
                    while(segmentPosition3 >= 1) 
                    { 
                        segmentTree[segmentPosition3] = Math.Max(segmentTree[2 * segmentPosition3], segmentTree[2 * segmentPosition3 + 1]); 
                        segmentPosition3 >>= 1; 
                    }
                }
            }

            return (int)validPermutationCount;
        }

        class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
        {
            List<(TElement Element, TPriority Priority)> data = new List<(TElement, TPriority)>();
            public int Count => data.Count;
            public IEnumerable<(TElement Element, TPriority Priority)> UnorderedItems => data;
            public void Enqueue(TElement element, TPriority priority)
            {
                data.Add((element, priority));
                int currentIndex = data.Count - 1;

                while(currentIndex > 0)
                {
                    int parentIndex = (currentIndex - 1) >> 1;
                    
                    if(data[currentIndex].Priority.CompareTo(data[parentIndex].Priority) >= 0)
                    {
                        break;
                    }

                    var tmp = data[currentIndex]; data[currentIndex] = data[parentIndex]; data[parentIndex] = tmp;
                    currentIndex = parentIndex;
                }
            }
            
            public TElement Dequeue()
            {
                var ret = data[0].Element;
                int lastIndex = data.Count - 1;
                data[0] = data[lastIndex];
                data.RemoveAt(lastIndex);
                int currentIndex = 0;

                while(true)
                {
                    int leftChildIndex = currentIndex * 2 + 1, rightChildIndex = leftChildIndex + 1;
                    int smallestIndex = currentIndex;
                    
                    if(leftChildIndex < data.Count && data[leftChildIndex].Priority.CompareTo(data[smallestIndex].Priority) < 0)
                    {
                        smallestIndex = leftChildIndex;
                    }

                    if(rightChildIndex < data.Count && data[rightChildIndex].Priority.CompareTo(data[smallestIndex].Priority) < 0) 
                    {
                        smallestIndex = rightChildIndex;
                    }

                    if(smallestIndex == currentIndex) 
                    {
                        break;
                    }

                    var tmp = data[currentIndex]; data[currentIndex] = data[smallestIndex]; data[smallestIndex] = tmp;
                    currentIndex = smallestIndex;
                }
                return ret;
            }
        }
    }
}