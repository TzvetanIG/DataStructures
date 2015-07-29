namespace ImplementArrayBasedStack
{
    using System;

    class ArrayStack<T>
    {
        private const int InitioalCapacity = 16;
        public T[] elements;

        public ArrayStack(int capacity = InitioalCapacity)
        {
            this.elements = new T[capacity];
            this.Capacity = capacity;
        }

        private int Capacity { get; set; }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Grow();
            }

            this.elements[Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.CheckForEmptyStack();

            var lastElement = this.elements[this.Count - 1];
            this.Count--;
            return lastElement;
        }

        public T[] ToArray()
        {
            this.CheckForEmptyStack();
            var stackElements = new T[this.Count];
            for (var i = 0; i < this.Count; i++)
            {
                stackElements[i] = this.elements[i];
            }

            return stackElements;
        }

        private void Grow()
        {
            this.Capacity *= 2;
            var newArray = new T[this.Capacity];
            for (var i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }

        private void CheckForEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
        }
        
    }
}
