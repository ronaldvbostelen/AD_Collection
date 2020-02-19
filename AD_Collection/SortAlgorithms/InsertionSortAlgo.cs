using System;
using System.Collections.Generic;

namespace AD_Collection.SortAlgorithms
{
    public static class InsertionSortAlgo
    {
        /*
         * InsertionSort =  take a item compare it with item before
         *                  if -1 put that item at its place, compare
         *                  with next until compare = 0, place it at
         *                  last swapped place
         */
        public static void InsertionSort<T>(this List<T> list) where T : IComparable
        {
            if (list.Count <= 1) return;

            for (int i = 1; i < list.Count; i++)
            {
                var idx = i;
                var toBeInsterted = list[i];

                while (idx > 0 && toBeInsterted.CompareTo(list[idx - 1]) < 0)
                {
                    list[idx] = list[--idx];
                }

                list[idx] = toBeInsterted;
            }
        }
    }
}