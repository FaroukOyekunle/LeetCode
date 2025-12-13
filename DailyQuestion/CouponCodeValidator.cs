using System.Text.RegularExpressions;

namespace DailyQuestion
{
    public class CouponCodeValidator
    {
        public IList<string> ValidateCoupons(string[] couponCodes, string[] businessLines, bool[] isActiveStatuses)
        {
            var businessPriorityOrder = new Dictionary<string, int>
        {
            { "electronics", 0 },
            { "grocery", 1 },
            { "pharmacy", 2 },
            { "restaurant", 3 }
        };

            var validCodeRegex = new Regex(@"^[a-zA-Z0-9_]+$");

            var validCouponList = new List<(string CouponCode, string BusinessLine)>();

            for(int couponIndex = 0; couponIndex < couponCodes.Length; couponIndex++)
            {
                if(!isActiveStatuses[couponIndex])
                {
                    continue;
                }

                if(string.IsNullOrEmpty(couponCodes[couponIndex]) || !validCodeRegex.IsMatch(couponCodes[couponIndex]))
                {
                    continue;
                }

                if(!businessPriorityOrder.ContainsKey(businessLines[couponIndex]))
                {
                    continue;
                }

                validCouponList.Add((couponCodes[couponIndex], businessLines[couponIndex]));
            }

            return validCouponList
                .OrderBy(coupon => businessPriorityOrder[coupon.BusinessLine])
                .ThenBy(coupon => coupon.CouponCode, StringComparer.Ordinal)
                .Select(coupon => coupon.CouponCode)
                .ToList();
        }
    }
}