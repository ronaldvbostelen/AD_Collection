using System.Linq;
using System.Text;

namespace AD_Collection.DataStructures
{
    public class MyArrayList : IMyArrayList
    {
        /*
         * ArrayList    = primitive array with specified capacity
         * add          = AFTER LAST
         * get          = @ index
         * set          = @ index
         */

        private int[] data;
        private int size;
        private int currentIndex;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
        }

        public void Add(int n)
        {
            if (size == data.Length)
            {
                throw new MyArrayListFullException();
            }

            data[currentIndex++] = n;
            size++;
        }

        public int Get(int index) => size == 0 || index < 0 || index > size - 1 ? throw new MyArrayListIndexOutOfRangeException() : data[index];

        public void Set(int index, int n)
        {
            if (index < 0 || index > size - 1 || data[index] == 0)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity() => data.Length;

        public int Size() => size;

        public void Clear()
        {
            data = new int[data.Length];
            size = currentIndex = 0;
        }

        public int CountOccurences(int n) => data.Count(x => x == n);

        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }

            var sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < size - 1; i++)
            {
                sb.Append(data[i] + ",");
            }

            sb.Append(data[size - 1] + "]");

            return sb.ToString();
        }
    }
}