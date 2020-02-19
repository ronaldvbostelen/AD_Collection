using System.Text;

namespace AD_Collection.DataStructures.LinkedList
{
    public class MyLinkedList<T> : IMyLinkedList<T>
    {
        /*
         * LinkedList   =   collection of NODES, list points to LAST node (we use add FIRST)
         *                  node point to next node, UNLIMITED SIZE
         * add          =   add FIRST 0 => 1
         * remove       =   remove FIRST (after first becomes first) 0 <= 1
         * insert       =   travers until at desired index
         */

        public MyNode<T> header;
        private int size;

        public void AddFirst(T data)
        {
            header = new MyNode<T> { data = data, next = header };
            size++;
        }

        public T GetFirst()
        {
            if (header == null)
            {
                throw new MyLinkedListEmptyException();
            }

            return header.data;
        }

        public void RemoveFirst()
        {
            if (header == null)
            {
                throw new MyLinkedListEmptyException();
            }

            header = header?.next;
            size--;
        }

        public int Size() => size;

        public void Clear()
        {
            header = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            if (index == 0)
            {
                header = new MyNode<T> { data = data, next = header?.next };
            }
            else
            {
                var beforeNode = header;

                for (int i = 1; i < index; i++)
                {
                    beforeNode = beforeNode.next;
                }

                beforeNode.next = new MyNode<T> { data = data, next = beforeNode.next };
            }

            size++;
        }

        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }

            var sb = new StringBuilder();
            sb.Append($"[{header.data},");

            var next = header.next;

            while (next != null)
            {
                sb.Append($"{next.data},");
                next = next.next;
            }

            sb[sb.Length - 1] = ']';

            return sb.ToString();
        }
    }
}