namespace Partition
{
    public class SinglyLinkedList
    {
        public Node Head { get; set; }

        public SinglyLinkedList() { }
        public SinglyLinkedList(System.Collections.Generic.IEnumerable<int> arr)
        {
            foreach (var item in arr)
            {
                this.InsertToTail(item);
            }
        }

        public void InsertToHead(int v)
        {
            if (this.Head == null)
            {
                this.Head = new Node(v);
                return;
            }

            var newHead = new Node(v);
            newHead.Next = this.Head;
            this.Head = newHead;
        }

        public void InsertToTail(int v)
        {
            var node = this.Head;
            if (node == null)
            {
                this.Head = new Node(v);
                return;
            }

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(v);
        }


        public void PrintAll()
        {
            this.Head?.PrintAll();
        }
    }

    public class Node
    {
        public Node(int v)
        {
            this.Value = v;
            this.Next = null;
        }

        public int Value { get; set; }
        public Node Next { get; set; }

        public void PrintAll()
        {
            var head = this;
            while (head != null)
            {                
                System.Console.Write($"{head.Value} ");
                head = head.Next;
            }
        }
    }
}