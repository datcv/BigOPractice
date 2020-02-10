namespace DeleteMiddleNode
{
    public class SinglyLinkedList
    {
        public Node Head { get; set; }

        public SinglyLinkedList(System.Collections.Generic.IEnumerable<int> arr)
        {
            foreach (var item in arr)
            {         
                this.InsertToTail(item);                
            }
        }

        public void InsertToTail(int v)
        {
            var node = this.Head;
            if (node == null){
                this.Head = new Node(v);
                return;
            }

            while(node.Next != null)
            {
                node = node.Next;                
            }

            node.Next = new Node(v);
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
    }
}