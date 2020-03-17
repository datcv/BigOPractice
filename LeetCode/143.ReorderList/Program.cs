using System;
using System.Collections.Generic;

namespace _143.ReorderList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ReorderList(ListNode head)
        {
            var l = new List<ListNode>();
            var temp = head;
            while (temp != null)
            {
                l.Add(temp);
                temp = temp.next;
            }

            int i = 0;
            var lastNode = new ListNode(-1);
            while (l.Count - 1 - i >= i)
            {
                lastNode.next = l[i];
                lastNode = l[l.Count - 1 - i];
                l[i].next = lastNode;
                i++;
            }

            lastNode.next = null;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
