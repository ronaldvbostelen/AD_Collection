namespace AD_Collection.DataStructures.Stack
{
    public interface IMystack<T>
    {
        bool IsEmpty();
        void Push(T data);
        T Top();
        T Pop();
	}
}