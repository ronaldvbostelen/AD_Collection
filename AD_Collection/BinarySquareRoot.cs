namespace AD_Collection
{
    public class BinarySquareRoot
    {
        public static int FindSquareRootBinary(int number)
        {
            double max = number;
            double min = 0;

            while (min <= max)
            {
                var mid = (max + min) / 2;
                var comp = mid * mid;

                if (comp > number + 1)
                {
                    max = mid;
                }
                else if (comp < number - 1)
                {
                    min = mid;
                }
                else
                {
                    return (int)mid;
                }
            }


            return 0;
        }
    }
}