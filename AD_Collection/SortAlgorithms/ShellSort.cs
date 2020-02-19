using System;
using System.Collections.Generic;

namespace AD_Collection.SortAlgorithms
{
    public static class ShellSortAlgo
    {
        /*
         * ShellSort    =   improved InsertionSort with gap compare/insert
         *                  compare items between gap-idx, until gap = 1
         *                  start gap at array.length/2.2 (= optimal division)
         */
        public static void ShellSort<T>(this List<T> list) where T : IComparable
        {
            for (var gap = list.Count / 2; gap > 0; gap = gap == 2 ? 1 : (int) (gap / 2.2))
            {
                for (int i = gap; i < list.Count; i++)
                {
                    var currentNumber = list[i]; // save 
                    var gapIdx = i; // incrementing gap index

                    for (; gapIdx >= gap && currentNumber.CompareTo(list[gapIdx - gap]) < 0; gapIdx -= gap) // shift values until 
                    {
                        // current.compare() >= 0
                        list[gapIdx] = list[gapIdx - gap];
                    }

                    list[gapIdx] = currentNumber; // put tmp at gapindex where tmp is bigger then list[j-gap]
                }
            }
        }
    }
}