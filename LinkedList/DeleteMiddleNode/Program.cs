using System;

namespace DeleteMiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new SinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var middleNode = l.Head.Next.Next;

            Console.WriteLine(middleNode.Value);

            RemoveMiddleNode(middleNode);
            PrintLinkedList(l);
        }

        private static void RemoveMiddleNode(Node middleNode)
        {            
            while (middleNode.Next != null)
            {
                middleNode.Value = middleNode.Next.Value;

                if (middleNode.Next.Next == null)
                {
                    middleNode.Next = null;
                }
                else{
                    middleNode = middleNode.Next;
                }
                
            }
        }

        private static void PrintLinkedList(SinglyLinkedList l)
        {
            var head = l.Head;
            while(head != null)
            {
                Console.Write($"{head.Value} ");
                head = head.Next;
            }
        }
    }
}
