using System;
using System.Collections;
using System.Collections.Generic;

//see https://stackoverflow.com/questions/1176416/implementing-ilist-interface/1176502#1176502
//for how to auto write this class
namespace CoWorkers
{
    public sealed class DisposableCollection<T> : IList<T>, IDisposable where T : IEnumerator
    {
        // This line is important. Without it the auto implementation creates only
        // methods with "NotImplemented" exceptions
        readonly IList<T> _list;

        public DisposableCollection(IEnumerable<T> collection)
        {
            _list = new List<T>();
            foreach (var item in collection)
            {
                _list.Add(item);
            }
        }

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public void Dispose()
        {


            GC.SuppressFinalize(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
