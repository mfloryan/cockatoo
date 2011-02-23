namespace mmSquare.Cockatoo
{
    using System.Collections;
    using System.Collections.Generic;

    public class BaseListCollection<T> : ICollection<T>
    {
        protected readonly List<T> ItemsCollection = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return ItemsCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            ItemsCollection.Add(item);
        }

        public void Clear()
        {
            ItemsCollection.Clear();
        }

        public bool Contains(T item)
        {
            return ItemsCollection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ItemsCollection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ItemsCollection.Remove(item);
        }

        public int Count
        {
            get { return ItemsCollection.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int i]
        {
            get { return ItemsCollection[i]; }
        }
    }
}
