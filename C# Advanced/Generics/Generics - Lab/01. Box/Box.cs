using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            this.BoxCollection = new List<T>();
        }
        public void Add(T element)
        {
            BoxCollection.Add(element);
        }

        public T Remove()
        {
            var element = this.BoxCollection[Count - 1];
            BoxCollection.Remove(BoxCollection[Count - 1]);
            return element;
        }

        public List<T> BoxCollection { get; set; }
        int Count { get { return BoxCollection.Count; } }
    }
}