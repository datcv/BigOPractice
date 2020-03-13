using System;
using System.Collections.Generic;

namespace _146.LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            // var cache = new LRUCache(2);
            // cache.Put(1, 1);
            // cache.Put(2, 2);
            // Console.WriteLine(cache.Get(1));       // returns 1
            // cache.Put(3, 3);    // evicts key 2
            // Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            // cache.Put(4, 4);    // evicts key 1
            // Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            // Console.WriteLine(cache.Get(3));       // returns 3
            // Console.WriteLine(cache.Get(4));       // returns 4

            var cache = new LRUCache(2);

            Console.WriteLine(cache.Get(2));       // returns -1
            cache.Put(2, 6);
            Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            cache.Put(1, 5);
            cache.Put(1, 2);
            Console.WriteLine(cache.Get(1));       // returns 2
            Console.WriteLine(cache.Get(2));       // returns 6            

        }
    }

    public class LRUCache
    {
        private int _capacity;
        private IDictionary<int, LinkedListNode<ValueNode>> _values = new Dictionary<int, LinkedListNode<ValueNode>>();
        private LinkedList<ValueNode> _recentUsedList = new LinkedList<ValueNode>();


        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (this._values.TryGetValue(key, out var v))
            {
                _recentUsedList.Remove(v);
                _recentUsedList.AddLast(v);
                return v.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (this._values.TryGetValue(key, out var v))
            {
                v.Value.Value = value;
                _recentUsedList.Remove(v);
                _recentUsedList.AddLast(v);
            }
            else
            {
                var newNode = new LinkedListNode<ValueNode>(new ValueNode(key, value));
                _recentUsedList.AddLast(newNode);
                this._values[key] = newNode;

                if (this._values.Count > this._capacity)
                {
                    if (this._recentUsedList.First != null)
                    {
                        this._values.Remove(this._recentUsedList.First.Value.Key);
                        this._recentUsedList.RemoveFirst();
                    }
                }
            }
        }

        class ValueNode
        {
            public ValueNode(int key, int value)
            {
                this.Key = key;
                this.Value = value;
            }

            public int Key { get; set; }
            public int Value { get; set; }
        }
    }
}
