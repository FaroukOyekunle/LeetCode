using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class PalindromeicPathQueriesinaTree
    {
        public IList<bool> PalindromePath(int nodeCount, int[][] edges, string nodeCharacters, string[] queries)
        {
            var adjacencyList = new List<int>[nodeCount];

            for (int currentNode = 0; currentNode < nodeCount; currentNode++)
            {
                adjacencyList[currentNode] = new List<int>();
            }

            foreach (int[] currentEdge in edges)
            {
                int firstEndpointNode = currentEdge[0];
                int secondEndpointNode = currentEdge[1];

                adjacencyList[firstEndpointNode].Add(secondEndpointNode);
                adjacencyList[secondEndpointNode].Add(firstEndpointNode);
            }

            int[] parentNodeByNode = new int[nodeCount];
            int[] depthByNode = new int[nodeCount];
            int[] depthFirstTraversalOrder = new int[nodeCount];
            int[] traversalStack = new int[nodeCount];

            Array.Fill(parentNodeByNode, -1);

            int traversalStackCount = 0;
            int traversalOrderCount = 0;

            traversalStack[traversalStackCount++] = 0;
            parentNodeByNode[0] = 0;

            while (traversalStackCount > 0)
            {
                int currentNode = traversalStack[--traversalStackCount];
                depthFirstTraversalOrder[traversalOrderCount++] = currentNode;

                foreach (int adjacentNode in adjacencyList[currentNode])
                {
                    if (adjacentNode == parentNodeByNode[currentNode])
                    {
                        continue;
                    }

                    parentNodeByNode[adjacentNode] = currentNode;
                    depthByNode[adjacentNode] = depthByNode[currentNode] + 1;
                    traversalStack[traversalStackCount++] = adjacentNode;
                }
            }

            int[] subtreeSizeByNode = new int[nodeCount];
            int[] heavyChildByNode = new int[nodeCount];

            Array.Fill(heavyChildByNode, -1);

            for (int traversalIndex = nodeCount - 1; traversalIndex >= 0; traversalIndex--)
            {
                int currentNode = depthFirstTraversalOrder[traversalIndex];
                subtreeSizeByNode[currentNode] = 1;

                int largestChildSubtreeSize = 0;

                foreach (int childNode in adjacencyList[currentNode])
                {
                    if (parentNodeByNode[childNode] != currentNode)
                    {
                        continue;
                    }

                    subtreeSizeByNode[currentNode] += subtreeSizeByNode[childNode];

                    if (subtreeSizeByNode[childNode] > largestChildSubtreeSize)
                    {
                        largestChildSubtreeSize = subtreeSizeByNode[childNode];
                        heavyChildByNode[currentNode] = childNode;
                    }
                }
            }

            int[] chainHeadByNode = new int[nodeCount];
            int[] linearPositionByNode = new int[nodeCount];
            int[] pendingChainStartNodes = new int[nodeCount];
            int[] pendingChainHeadNodes = new int[nodeCount];

            int pendingChainCount = 0;
            int nextLinearPosition = 0;

            pendingChainStartNodes[pendingChainCount] = 0;
            pendingChainHeadNodes[pendingChainCount++] = 0;

            while (pendingChainCount > 0)
            {
                pendingChainCount--;

                int currentChainNode = pendingChainStartNodes[pendingChainCount];
                int currentChainHeadNode = pendingChainHeadNodes[pendingChainCount];

                while (currentChainNode != -1)
                {
                    chainHeadByNode[currentChainNode] = currentChainHeadNode;
                    linearPositionByNode[currentChainNode] = nextLinearPosition++;

                    foreach (int childNode in adjacencyList[currentChainNode])
                    {
                        if (parentNodeByNode[childNode] == currentChainNode && childNode != heavyChildByNode[currentChainNode])
                        {
                            pendingChainStartNodes[pendingChainCount] = childNode;
                            pendingChainHeadNodes[pendingChainCount++] = childNode;
                        }
                    }

                    currentChainNode = heavyChildByNode[currentChainNode];
                }
            }

            char[] currentCharacterByNode = nodeCharacters.ToCharArray();
            int[] characterMasksByLinearPosition = new int[nodeCount];

            for (int currentNode = 0; currentNode < nodeCount; currentNode++)
            {
                characterMasksByLinearPosition[linearPositionByNode[currentNode]] = 1 << (currentCharacterByNode[currentNode] - 'a');
            }

            var characterMaskSegmentTree = new SegmentTree(characterMasksByLinearPosition);
            var queryAnswers = new List<bool>();

            foreach (string currentQuery in queries)
            {
                string[] queryParts = currentQuery.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                if (queryParts[0] == "update")
                {
                    int nodeToUpdate = int.Parse(queryParts[1]);
                    char replacementCharacter = queryParts[2][0];

                    currentCharacterByNode[nodeToUpdate] = replacementCharacter;

                    int replacementCharacterMask = 1 << (replacementCharacter - 'a');

                    characterMaskSegmentTree.Update(linearPositionByNode[nodeToUpdate], replacementCharacterMask);
                }
                else
                {
                    int firstPathEndpointNode = int.Parse(queryParts[1]);
                    int secondPathEndpointNode = int.Parse(queryParts[2]);

                    int combinedPathCharacterMask = 0;

                    while (chainHeadByNode[firstPathEndpointNode]
                        != chainHeadByNode[secondPathEndpointNode])
                    {
                        if (depthByNode[chainHeadByNode[firstPathEndpointNode]] < depthByNode[chainHeadByNode[secondPathEndpointNode]])
                        {
                            int temporaryNode = firstPathEndpointNode;
                            firstPathEndpointNode = secondPathEndpointNode;
                            secondPathEndpointNode = temporaryNode;
                        }

                        int currentChainHeadNode = chainHeadByNode[firstPathEndpointNode];

                        combinedPathCharacterMask ^= characterMaskSegmentTree.Query(linearPositionByNode[currentChainHeadNode], linearPositionByNode[firstPathEndpointNode]);

                        firstPathEndpointNode = parentNodeByNode[currentChainHeadNode];
                    }

                    int pathSegmentStartPosition = Math.Min(linearPositionByNode[firstPathEndpointNode], linearPositionByNode[secondPathEndpointNode]);

                    int pathSegmentEndPosition = Math.Max(linearPositionByNode[firstPathEndpointNode], linearPositionByNode[secondPathEndpointNode]);

                    combinedPathCharacterMask ^= characterMaskSegmentTree.Query(pathSegmentStartPosition, pathSegmentEndPosition);

                    queryAnswers.Add((combinedPathCharacterMask & (combinedPathCharacterMask - 1)) == 0);
                }
            }

            return queryAnswers;
        }

        private class SegmentTree
        {
            private readonly int leafCount;
            private readonly int[] xorTree;

            public SegmentTree(int[] initialValues)
            {
                leafCount = initialValues.Length;
                xorTree = new int[leafCount * 2];

                for (int leafIndex = 0; leafIndex < leafCount; leafIndex++)
                {
                    xorTree[leafCount + leafIndex] = initialValues[leafIndex];
                }

                for (int parentNodeIndex = leafCount - 1; parentNodeIndex > 0; parentNodeIndex--)
                {
                    xorTree[parentNodeIndex] = xorTree[parentNodeIndex * 2] ^ xorTree[parentNodeIndex * 2 + 1];
                }
            }

            public void Update(int position, int replacementValue)
            {
                int currentTreeNodeIndex = leafCount + position;
                xorTree[currentTreeNodeIndex] = replacementValue;

                while (currentTreeNodeIndex > 1)
                {
                    currentTreeNodeIndex /= 2;

                    xorTree[currentTreeNodeIndex] = xorTree[currentTreeNodeIndex * 2] ^ xorTree[currentTreeNodeIndex * 2 + 1];
                }
            }

            public int Query(int rangeStartPosition, int rangeEndPosition)
            {
                int combinedXorResult = 0;

                int leftTreeNodeIndex = leafCount + rangeStartPosition;
                int rightTreeNodeIndex = leafCount + rangeEndPosition;

                while (leftTreeNodeIndex <= rightTreeNodeIndex)
                {
                    if ((leftTreeNodeIndex & 1) == 1)
                    {
                        combinedXorResult ^= xorTree[leftTreeNodeIndex];
                        leftTreeNodeIndex++;
                    }

                    if ((rightTreeNodeIndex & 1) == 0)
                    {
                        combinedXorResult ^= xorTree[rightTreeNodeIndex];
                        rightTreeNodeIndex--;
                    }

                    leftTreeNodeIndex /= 2;
                    rightTreeNodeIndex /= 2;
                }

                return combinedXorResult;
            }
        }
    }
}