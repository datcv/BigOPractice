using System;
using System.Collections.Generic;

namespace _138.CopyListwithRandomPointer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
        }

        public static Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            var clonedHead = new Node(-1);
            var oldToNewDict = new Dictionary<Node, Node>();
            
            var temp = head;
            var tempClone = clonedHead;
            while (temp != null)
            {
                if (oldToNewDict.TryGetValue(temp, out var cloneTemp))
                {                    
                    tempClone.next = cloneTemp;
                }
                else
                {
                    cloneTemp = new Node(temp.val);                    
                    oldToNewDict[temp] = cloneTemp;
                    tempClone.next = cloneTemp;
                }

                if (temp.random != null)
                {
                    if (oldToNewDict.TryGetValue(temp.random, out var newRandomNode))
                    {
                        cloneTemp.random = newRandomNode;
                    }
                    else
                    {
                        var cloneRandomNode = new Node(temp.random.val);
                        cloneTemp.random = cloneRandomNode;
                        oldToNewDict[temp.random] = cloneRandomNode;
                    }
                }
                
                temp = temp.next;                
                tempClone = tempClone.next;
            }

            return clonedHead.next;
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
