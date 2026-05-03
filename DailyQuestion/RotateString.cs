namespace DailyQuestion
{
    public class RotateString
    {
        public bool IsRotationOfOriginalString(string originalString, string targetString)
        {
            if (originalString.Length != targetString.Length)
            {
                return false;
            }

            string concatenatedString = originalString + originalString;

            bool isRotationMatchFound = concatenatedString.Contains(targetString);

            return isRotationMatchFound;
        }
    }
}