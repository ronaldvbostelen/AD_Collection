using System.Collections.Generic;
using System.Linq;

namespace AD_Collection.DataStructures.Queue
{
    public class MyQueue<T> : IMyQueue<T>
    {
        /*
         * Queue    = collection is List class, FIFO, unlimited (in this case)
         * Enqueue  = add last in line
         * Dequeue  = remove first in line (added FIRST)
         * GetFront = get firstly added object
         */

        private List<T> list;

        public MyQueue()
        {
            this.list = new List<T>();
        }

        public bool IsEmpty() => list.Count == 0;

        public void Enqueue(T data) => list.Add(data);

        public T GetFront() => IsEmpty() ? throw new MyQueueEmptyException() : list.First();

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            var first = list.First();
            list.Remove(first);
            return first;
        }

        public void Clear() => list.Clear();
    }
}