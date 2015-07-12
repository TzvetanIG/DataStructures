namespace ImplementTheDataStructureReversedList
{
    using System;
    using System.Collections;

    public class ReversedList<T> : IEnumerable, IEnumerator
    {
        private int currentPosition = -1;

        public ReversedList(int capacity)
        {
            this.Capacity = capacity;
            this.Storage = new T[capacity];
            this.Count = 0;
        }

        public int Capacity { get; private set; }

        private T[] Storage { get; set; }

        public int Count { get; private set; }

        public void Add(T item)
        {

            if (this.Count == this.Capacity)
            {
                this.DoubleStorage();
            }

            Storage[Count] = item;
            this.Count++;
            this.currentPosition = this.Count;
        }


        public T Remove(int index)
        {
            ValidateIndex(index);
            var reverseIndex = this.Count - 1 - index;
            var newStorage = new T[this.Capacity];
            var j = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (i != reverseIndex)
                {
                    newStorage[j] = Storage[i];
                    j++;
                }
            }

            this.Count--;
            var removedElement = this.Storage[index];
            this.Storage = newStorage;
            this.currentPosition = this.Count;
            return removedElement;
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return Storage[this.Count - 1 - index];
            }

            set
            {
                ValidateIndex(index);
                Storage[this.Count - 1 - index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            this.currentPosition--;
            return (this.currentPosition >= 0);
        }

        public void Reset()
        {
            this.currentPosition = this.Count;
        }

        public object Current
        {
            get { return this.Storage[currentPosition]; }
        }


        private void DoubleStorage()
        {
            this.Capacity = 2 * this.Capacity;
            var newStorage = new T[this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newStorage[i] = this.Storage[i];
            }

            this.Storage = newStorage;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
