namespace PlayWithTrees
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Tree<T>
    {
        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public IList Children { get; set; }

        public IList<T> ToList()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            var values = new List<T>();

            while (queue.Count > 0)
            {
                var nextNode = queue.Dequeue();
                values.Add(nextNode.Value);
                var children = nextNode.Children;
                foreach (Tree<T> child in children)
                {
                    queue.Enqueue(child);
                }
            }

            return values;
        }
    }

}
