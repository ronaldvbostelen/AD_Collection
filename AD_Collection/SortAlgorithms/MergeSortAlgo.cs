using System;
using System.Collections.Generic;

namespace AD_Collection.SortAlgorithms
{
    public static class MergeSortAlgo
    {
        /*
         * MergeSort    =   HARDCORE ALGORITHM
         *                  called function is driverfuction (creates temp list / sets arguments for recursive fuction)
         *                  Sort() is recursive => magic (EXPLAIN LATER)
         *                  Merge() sorts elements (in temp array) + copies it back to array
         */
        public static void MergeSort<T>(this List<T> list) where T : IComparable
        {
            if (list.Count <= 1) return;

            Sort(list, new T[list.Count], 0, list.Count - 1);
        }

        private static void Sort<T>(List<T> a, T[] tempArray, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int center = (left + right) / 2;
                Sort(a, tempArray, left, center);
                Sort(a, tempArray, center + 1, right);
                Merge(a, tempArray, left, center + 1, right);
            }
        }

        private static void Merge<T>(List<T> a, T[] tempArray, int leftPos, int rightPos, int rightEnd) where T : IComparable
        {
            var leftEnd = rightPos - 1;
            var tmpIdx = leftPos;
            var numbOfElements = rightEnd - leftPos + 1;

            while (leftPos <= leftEnd && rightPos <= rightEnd)
            {
                if (a[leftPos].CompareTo(a[rightPos]) <= 0)
                {
                    tempArray[tmpIdx++] = a[leftPos++];
                }
                else
                {
                    tempArray[tmpIdx++] = a[rightPos++];
                }
            }

            while (rightPos <= rightEnd)
            {
                tempArray[tmpIdx++] = a[rightPos++];
            }

            while (leftPos <= leftEnd)
            {
                tempArray[tmpIdx++] = a[leftPos++];
            }

            for (int i = 0; i < numbOfElements; i++, rightEnd--)
            {
                a[rightEnd] = tempArray[rightEnd];
            }
        }
    }
}