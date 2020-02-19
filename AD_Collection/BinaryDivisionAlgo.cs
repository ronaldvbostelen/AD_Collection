namespace AD_Collection
{
    public class BinaryDivisionAlgo
    {
        public static int BinaryDivision(int numerator, int denominator)
        {
            var max = numerator;
            var min = 1;

            while (min <= max)
            {
                var mid = (max + min) / 2;

                if (mid * denominator < numerator)
                {
                    min = mid + 1;
                }
                else if (mid * denominator > numerator)
                {
                    max = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return max;
        }
    }
}