using System;
using System.Collections.Generic;

namespace _92.ReverseLinkedListII
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(3){
                next = new ListNode(5)
            };

            var l = ReverseBetween(head, 1, 2);
            l.Print();
        }

        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var s = new Stack<ListNode>();
            var temp = head;
            var i = 1;
            var mid = m + (n - m) / 2 + (n - m) % 2;
            while (i <= n && temp != null)
            {
                if (i >= m)
                {
                    if (i < mid)
                    {
                        s.Push(temp);
                    }
                    else if (s.Count == n - i + 1)
                    {
                        var t = s.Pop();
                        var v = t.val;
                        t.val = temp.val;
                        temp.val = v;
                    }
                }

                temp = temp.next;
                i++;
            }

            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public void Print()
        {
            var t = this;
            while (t != null)
            {
                Console.Write($" {t.val}");
                t = t.next;
            }
        }
    }
}
