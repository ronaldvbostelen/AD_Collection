using AD_Collection.DataStructures.LinkedList;

namespace AD_Collection.DataStructures.Stack
{
    public class MyStack<T> : IMystack<T>
    {
        /*
         * Stack    = linkedList collection, LIFO, unlimited in size
         * Pop      = remove LAST object added
         * Push     = add FIRST item
         * Top      = peak at first item to be popped
         */
        private readonly MyLinkedList<T> linkedList;

        public MyStack()
        {
            linkedList = new MyLinkedList<T>();
        }

        public bool IsEmpty() => linkedList.Size() == 0;

        public T Pop()
        {
            if (linkedList.Size() == 0)
            {
                throw new MyStackEmptyException();
            }

            var pop = linkedList.GetFirst();
            linkedList.RemoveFirst();
            return pop;
        }

        public void Push(T data) => linkedList.AddFirst(data);

        public T Top()
        {
            if (linkedList.Size() == 0)
            {
                throw new MyStackEmptyException();
            }

            return linkedList.GetFirst();
        }
    }
}