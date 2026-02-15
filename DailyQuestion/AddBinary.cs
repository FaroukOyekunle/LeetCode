namespace DailyQuestion
{
    public class AddBinary
    {
        public string AddBinaryStrings(string binaryStringA, string binaryStringB)
        {
            int pointerA = binaryStringA.Length - 1;
            int pointerB = binaryStringB.Length - 1;

            int carryOver = 0;
            var binarySumResult = new System.Text.StringBuilder();

            while (pointerA >= 0 || pointerB >= 0 || carryOver > 0)
            {
                int currentSum = carryOver;

                if (pointerA >= 0)
                {
                    currentSum += binaryStringA[pointerA] - '0'; 
                    pointerA--;
                }

                if (pointerB >= 0)
                {
                    currentSum += binaryStringB[pointerB] - '0';
                    pointerB--;
                }

                binarySumResult.Append(currentSum % 2);

                carryOver = currentSum / 2;
            }

            char[] reversedResultArray = binarySumResult.ToString().ToCharArray();
            Array.Reverse(reversedResultArray);

            return new string(reversedResultArray);
        }
    }
}