using System;

namespace _21.MergeTwoSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            var d = new ListNode(-1);
            var m = d;
            var n1 = l1;
            var n2 = l2;
            while (n1 != null && n2 != null)
            {
                if (n1.val < n2.val)
                {
                    m.next = n1;
                    n1 = n1.next;
                }
                else
                {
                    m.next = n2;
                    n2 = n2.next;
                }

                m = m.next;
            }

            if (n1 != null)
            {
                m.next = n1;
            }

            if (n2 != null)
            {
                m.next = n2;
            }

            return d.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
