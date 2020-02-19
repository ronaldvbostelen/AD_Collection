namespace AD_Collection
{
    public static class Recursion
    {
        #region StringReverse

        public static string Reverse(string reverse)
        {
            if (reverse == string.Empty)
            {
                return reverse;
            }

            return Reverse(reverse.Substring(1)) + reverse[0];
        }

        #endregion
        #region Factorial

        public static long FactorialRecursive(long factorial)
        {
            if (factorial <= 1)
            {
                return 1;
            }

            return factorial * FactorialRecursive(factorial - 1);
        }

        #endregion


    }
}