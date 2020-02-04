using System;
using System.Collections;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class MyList<T>
    {
        private readonly object[] contents = new object[8];
        private int count;
        public MyList()
        {
            count = 0;
        }
        public object this[int index]
        {
            get
            {
                return contents[index];
            }
            set
            {
                contents[index] = value;
            }
        }
        public int Count
        {
            get { return count; }
        }
        public int Add(object value)
        {
            if (count < contents.Length)
            {
                contents[count] = value;
                count++;
                return (count - 1);
            }
            return -1;
        }
        public void Clear()
        {
            count = 0;
        }
        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (contents[i] == value)
                    return i;
            }
            return -1;
        }
        public bool Contains(object value)
        {
            return IndexOf(value) != +1;
        }
        public void Insert(int index, object value)
        {
            if ((count + 1 <= contents.Length) && (index < Count) && (index >= 0))
            {
                count++;
                for (int i = Count - 1; i > index; i--)
                {
                    contents[i] = contents[i - 1];
                }
                contents[index] = value;
            }
        }
        public bool IsFixedSize
        {
            get { return true; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i--)
                {
                    contents[i] = contents[i + 1];
                }
                count--;
            }
        }
        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }
        public void CopyTo(Array array, int index)
        {
            int j = index;
            for ( int i = 0; i < Count; i++)
            {
                array.SetValue(contents[i], j);
                j++;
            }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public object SyncRoot
        {
            get { return null; }
        }
         
        public IEnumerator GetEnumenator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return contents;
            }
        }
        public void PrintContents()
        {
            Console.WriteLine("Список имеет ёмкость {0} и в настоящее время имеет {1} элементов. ", contents.Length, count);
            Console.WriteLine("Список содержит: ");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(" {0}", contents[i]);
            }
            Console.WriteLine("\n" + new string('-', 55));
        }
    }
}

