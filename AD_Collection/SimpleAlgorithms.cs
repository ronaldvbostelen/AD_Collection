using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD_Collection
{ // ctrl m
    static class SimpleAlgorithms
    {
        #region MovingAverage
        public static double[] MovingAverage(int[] array, int n)
        {
            var movingavrage = new double[array.Length];
            var sum = 0;
            var divisor = n;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (i < n) divisor = i + 1;

                if (i >= n) sum -= array[i - n];

                movingavrage[i] = (double)sum / divisor;
            }

            return movingavrage;

        }

        #endregion
        #region CombineArrays
        public static T[] Combine<T>(T[] first, T[] second) where T : IComparable
        {
            var combined = new T[first.Length + second.Length];
            var idxA = 0;
            var idxB = 0;

            for (int i = 0; i < combined.Length; i++)
            {
                if (idxA == first.Length && idxB < second.Length || idxB < second.Length && first[idxA].CompareTo(second[idxB]) > 0)
                {
                    combined[i] = second[idxB];
                    idxB++;
                }
                else
                {
                    combined[i] = first[idxA];
                    idxA++;
                }
            }

            return combined;
        }


        #endregion
        #region CreateHistogram

        public static Dictionary<Tuple<int, int>, List<int>> CreateHistogram(int[] array, int[] bins)
        {
            var dict = new Dictionary<Tuple<int, int>, List<int>>();

            for (int i = 1; i < bins.Length; i++)
            {
                dict.Add(new Tuple<int, int>(bins[i - 1], bins[i] - 1), new List<int>());
            }

            foreach (var value in array)
            {
                var key = dict.Keys.Single(x => value >= x.Item1 && value <= x.Item2);
                dict[key].Add(value);
            }

            return dict;
        }

        #endregion
        #region ValueExistsInArray (naive & O(N2))

        public static bool ValueExists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) return true;
            }

            return false;
        }

        public static bool ValueExists_v2(int[] array, int number)
        {
            var boolsArray = CreateBoolArray(array);

            return boolsArray[number];
        }

        private static bool[] CreateBoolArray(int[] array)
        {
            var bools = new bool[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > bools.Length)
                {
                    Array.Resize(ref bools, array[i] * 2);
                }

                bools[array[i]] = true;
            }

            return bools;
        }


        #endregion
        #region Nearest point with EuclideanDistance

        public static int IndexOfNearestPoint(int[,] cords, int[] point, double maxDistance)
        {
            double nearestPoint = -1;
            var idx = 0;

            for (int i = 0; i < cords.GetLength(0); i++)
            {
                var distance = ComputeEuclideanDistance(cords[i, 0], cords[i, 1], point[0], point[1]);
                if (distance <= maxDistance && (nearestPoint < 0 || distance < nearestPoint))
                {
                    nearestPoint = distance;
                    idx = i;
                }
            }

            return nearestPoint >= 0 ? idx : -1;
        }

        private static double ComputeEuclideanDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        #endregion
        #region BabyloniaSquareRoot

        public static int BabyloniaSquareRoot(int number)
        {
            double mid = (double)number / 2;
            double comp = number / mid;

            while (Math.Abs(mid - comp) > .25)
            {
                mid = (mid + comp) / 2;
                comp = number / mid;
            }

            return (int)mid;
        }

        #endregion
        #region FizzBuzz

        public static void Print(int amount)
        {
            for (int i = 1; i <= amount; i++)
            {
                var modThree = i % 3;
                var modFive = i % 5;

                if (modThree == 0 || modFive == 0)
                {
                    var fizz = modThree == 0 ? "Fizz" : "";
                    var buzz = modFive == 0 ? "Buzz" : "";
                    Console.WriteLine(fizz + buzz + ", ");
                }
                else
                {
                    Console.WriteLine(i + ", ");
                }
            }
        }

        #endregion
        #region Fibonacci Iterative

        public static long FibonacciIterative(int n)
        {
            var a = 0;
            var b = 1;
            var fib = a + b;

            while (n-- > 0)
            {
                fib = a + b;
                a = b;
                b = fib;
            }

            return fib;
        }

        #endregion

    }
}
