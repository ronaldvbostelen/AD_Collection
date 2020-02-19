using System;
using System.Collections.Generic;

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
        #region Fibonacci

        public static long FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        #endregion
        #region OmEnOm

        public static int OmEnOm(int n)
        {
            if (n < 0) throw new ArgumentException();

            if (n <= 1) return n;

            return n + OmEnOm(n - 2);
        }

        #endregion
        #region Transform base 10 to binaryNotation

        public static int Enen(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return (n % 2 == 0 ? 0 : 1) + Enen(n / 2);
        }

        #endregion
        #region Create forward string from list item

        public static string ForwardString(List<int> list, int from)
        {
            if (from >= list.Count)
            {
                return "";
            }

            return list[from] + " " + ForwardString(list, ++from);
        }

        #endregion
        #region Create backwards string from list items

        public static string BackwardString(List<int> list, int to)
        {
            if (to >= list.Count)
            {
                return "";
            }

            return BackwardString(list, to + 1) + " " + list[to];
        }

        #endregion
    }
}