namespace ImplementLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public Node(T value, Node nextNode)
            {
                this.Value = value;
                this.Next = nextNode;
            }

            public Node()
            {
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        public LinkedList()
        {
            this.CurrentNode = new Node();
        }

        private Node Head { get; set; }

        private Node Tail { get; set; }

        public int Count { get; set; }

        private Node CurrentNode { get; set; }

        public void Add(T item)
        {
            var nextNode = new Node(item, null);
            if (this.Count == 0)
            {
                this.Tail = nextNode;
                this.Head = nextNode;
            }
            else
            {
                this.Tail.Next = nextNode;
                this.Tail = nextNode;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            ValidateIndex(index);

            Node node = this.Head;
            var i = 1;
            while (i < index)
            {
                node = node.Next;
                i++;
            }

            if (index == 0)
            {
                this.Head = node.Next;
                return node.Value;
            }

            var nextNode = node.Next;
            node.Next = nextNode.Next;

            if (index == this.Count - 1)
            {
                this.Tail = node;
            }

            this.Count--;
            return nextNode.Value;
        }

        public int FirstIndexOf(T item)
        {
            var node = this.Head;
            var index = -1;
            var itemIndex = -1;
            while (node != null)
            {
                index++;
                if (item.Equals(node.Value))
                {
                    itemIndex = index;
                    break;
                }

                node = node.Next;
            }

            return itemIndex;
        }

        public int LastIndexOf(T item)
        {
            var node = this.Head;
            var index = -1;
            var itemIndex = -1;
            while (node != null)
            {
                index++;
                if (item.Equals(node.Value))
                {
                    itemIndex = index;
                }

                node = node.Next;
            }

            return itemIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.CurrentNode = this.Head;
            while (this.CurrentNode != null)
            {
                yield return CurrentNode.Value;
                CurrentNode = CurrentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
