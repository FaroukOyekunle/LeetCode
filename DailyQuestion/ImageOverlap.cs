namespace DailyQuestion
{
    public class ImageOverlap
    {
        public int LargestOverlap(int[][] firstImage, int[][] secondImage)
        {
            int imageSize = firstImage.Length;
            int maximumOverlapCount = 0;

            for (int rowTranslation = -(imageSize - 1); rowTranslation <= imageSize - 1; rowTranslation++)
            {
                for (int columnTranslation = -(imageSize - 1); columnTranslation <= imageSize - 1; columnTranslation++)
                {
                    int currentOverlapCount = 0;

                    for (int firstImageRow = 0; firstImageRow < imageSize; firstImageRow++)
                    {
                        int correspondingSecondImageRow = firstImageRow + rowTranslation;

                        if (correspondingSecondImageRow < 0 || correspondingSecondImageRow >= imageSize)
                        {
                            continue;
                        }

                        for (int firstImageColumn = 0; firstImageColumn < imageSize; firstImageColumn++)
                        {
                            int correspondingSecondImageColumn = firstImageColumn + columnTranslation;

                            if (correspondingSecondImageColumn < 0 || correspondingSecondImageColumn >= imageSize)
                            {
                                continue;
                            }

                            if (firstImage[firstImageRow][firstImageColumn] == 1 && secondImage[correspondingSecondImageRow][correspondingSecondImageColumn] == 1)
                            {
                                currentOverlapCount++;
                            }
                        }
                    }

                    maximumOverlapCount = Math.Max(maximumOverlapCount, currentOverlapCount);
                }
            }

            return maximumOverlapCount;
        }
    }
}