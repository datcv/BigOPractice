using System;

namespace Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            var partitionVal = 5;

            var l = new SinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 5, 9 });

            Node head = null, left = null, tail = null;

            var newLinkedList = new SinglyLinkedList();

            var node = l.Head;
            while (node != null)
            {
                if (node.Value < partitionVal)
                {
                    if (left == null)
                    {
                        head = new Node(node.Value);
                        left = head;
                    }
                    else
                    {
                        var newLeft = new Node(node.Value);
                        left.Next = newLeft;
                        left = newLeft;
                    }
                }
                else
                {
                    if (tail == null){
                        tail = new Node(node.Value);
                    }
                    else{
                        var newTail = new Node(node.Value);
                        newTail.Next = tail;
                        tail = newTail;
                    }
                }

                node = node.Next;
            }

            if (left != null){
                left.Next = tail;
            }
            else {
                head = tail;
            }


            head?.PrintAll();

        }


    }
}
