using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class MaximizeConsecutiveElementsinanArrayAfterModification
    {

        public int[] FindSubtreeSizes(int[] originalParentByNode, string nodeLabels)
        {
            int totalNodeCount = originalParentByNode.Length;

            List<int>[] originalTreeChildrenByNode = new List<int>[totalNodeCount];

            for (int nodeIndex = 0; nodeIndex < totalNodeCount; nodeIndex++)
            {
                originalTreeChildrenByNode[nodeIndex] = new List<int>();
            }

            for (int nodeIndex = 1; nodeIndex < totalNodeCount; nodeIndex++)
            {
                int originalParentNode = originalParentByNode[nodeIndex];

                originalTreeChildrenByNode[originalParentNode].Add(nodeIndex);
            }

            int[] nearestAncestorNodeByCharacter = new int[26];
            Array.Fill(nearestAncestorNodeByCharacter, -1);

            int[] reassignedParentByNode = (int[])originalParentByNode.Clone();

            void ReassignParentsToNearestMatchingAncestor(int currentNode)
            {
                int currentNodeCharacterIndex = nodeLabels[currentNode] - 'a';

                int previousNearestAncestorNode = nearestAncestorNodeByCharacter[currentNodeCharacterIndex];

                if (previousNearestAncestorNode != -1)
                {
                    reassignedParentByNode[currentNode] = previousNearestAncestorNode;
                }

                nearestAncestorNodeByCharacter[currentNodeCharacterIndex] = currentNode;

                foreach (int childNode in originalTreeChildrenByNode[currentNode])
                {
                    ReassignParentsToNearestMatchingAncestor(childNode);
                }

                nearestAncestorNodeByCharacter[currentNodeCharacterIndex] = previousNearestAncestorNode;
            }

            ReassignParentsToNearestMatchingAncestor(0);

            List<int>[] reassignedTreeChildrenByNode = new List<int>[totalNodeCount];

            for (int nodeIndex = 0; nodeIndex < totalNodeCount; nodeIndex++)
            {
                reassignedTreeChildrenByNode[nodeIndex] = new List<int>();
            }

            for (int nodeIndex = 1; nodeIndex < totalNodeCount; nodeIndex++)
            {
                int reassignedParentNode = reassignedParentByNode[nodeIndex];

                reassignedTreeChildrenByNode[reassignedParentNode].Add(nodeIndex);
            }

            int[] subtreeSizeByNode = new int[totalNodeCount];

            int CalculateAndStoreSubtreeSize(int currentNode)
            {
                int currentSubtreeSize = 1;

                foreach (int childNode in reassignedTreeChildrenByNode[currentNode])
                {
                    currentSubtreeSize += CalculateAndStoreSubtreeSize(childNode);
                }

                subtreeSizeByNode[currentNode] = currentSubtreeSize;

                return currentSubtreeSize;
            }

            CalculateAndStoreSubtreeSize(0);

            return subtreeSizeByNode;
        }
    }
}