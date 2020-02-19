namespace AD_Collection
{
    public static class BinarySearchAlgo
    {
        public static int BinarySearch(int[] array, int number)
        {
            var max = array.Length - 1;
            var bot = 0;

            while (bot <= max)
            {
                var mid = (max + bot) / 2;
                var comp = array[mid].CompareTo(number);

                if (comp > 0)
                {
                    max = mid - 1;
                }
                else if (comp < 0)
                {
                    bot = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}