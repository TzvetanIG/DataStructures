namespace LinkedStack
{
    using System;

    class LinkedStack<T>
    {
        private Node<T> firstNode;
        
        public LinkedStack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (firstNode == null)
            {
                firstNode = new Node<T>(element, null);
            }
            else
            {
                var newNode =  new Node<T>(element, this.firstNode);
                this.firstNode = newNode;
            }

            this.Count++;
        }

        public T Pop()
        {
            CheckForEmptyStack();
            var firstElement = this.firstNode.Value;
            this.firstNode.PrevNode = null;
            this.Count--;
            return firstElement;
        }

        public T[] ToArray()
        {
            this.CheckForEmptyStack();
            var currentNode = this.firstNode;
            var elements = new T[this.Count];
            var i = 0;
            while (currentNode != null)
            {
                elements[i] = currentNode.Value;
                currentNode = currentNode.PrevNode;
                i++;
            }

            return elements;
        }

        private void CheckForEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
        }
        
        private class  Node<T>
        {
            public Node(T value, Node<T> prevNode)
            {
                this.Value = value;
                this.PrevNode = prevNode;
            }

            public T Value { get; private set; }

            public Node<T> PrevNode { get; set; }
        }
    }
}
